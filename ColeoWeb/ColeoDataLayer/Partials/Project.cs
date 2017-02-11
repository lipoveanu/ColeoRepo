using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ColeoDataLayer.ModelColeo
{
    public partial class Project
    {
        #region Properties

        public List<UserProject> UsersProject { get; set; }

        #endregion Properties

        public static List<Project> All()
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                return context.Projects
                    .Include(x => x.ProjectStatus)
                    .Include(x => x.Project1)
                    .ToList();
            }
        }

        public static List<Project> AllByUser(string userName)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                return context.Projects.Where(d => d.AspNetUser.Id == userName).ToList();
            }
        }

        public List<Project> AllByStatus(string userName, int idStatus)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                return context.Projects.Where(d => d.AspNetUser.Id == userName && d.ProjectStatus.Id == idStatus).ToList();
            }
        }

        public static Project GetById(int id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var project = context.Projects
                    .Include(d => d.AspNetUser)
                    .Include(d => d.UserProjects)
                    .Include(d => d.ProjectFiles.Select(x => x.File))
                    .Include(d => d.File)
                    .FirstOrDefault(d => d.Id == id);


                project.UsersProject = project.UserProjects.ToList();

                return project;
            }
        }

        public static int Save(Project entity)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                //add to db
                context.Projects.Add(entity);

                //Project status
                ProjectStatus projectStatus = context.ProjectStatuses.FirstOrDefault(x => x.Id == entity.IdStatus);
                if (projectStatus != null)
                {
                    entity.ProjectStatus = projectStatus;
                }

                context.SaveChanges();

                Project.Update(entity);

                return entity.Id;
            }
        }

        public static void Update(Project entity)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                Project project = context.Projects.FirstOrDefault(d => d.Id == entity.Id);

                if (project == null)
                {
                    return;
                }

                //set properties
                project.Name = entity.Name;
                project.Description = entity.Description;
                project.DateCreated = entity.DateCreated;
                project.Color = entity.Color;

                //Parent project
                Project projectParent = context.Projects.FirstOrDefault(x => x.Id == entity.IdParentProject);
                if (projectParent != null)
                {
                    project.Project1 = projectParent;
                }

                //User created
                AspNetUser userCreated = context.AspNetUsers.FirstOrDefault(x => x.Id == entity.IdUserCreated);
                if (userCreated != null)
                {
                    project.AspNetUser = userCreated;
                }

                //File ????
                List<int> dbProjectFile = project.ProjectFiles.Select(x => x.IdFile).ToList();
                List<int> modelProjectFile = entity.ProjectFiles.Select(x => x.IdFile).ToList();

                modelProjectFile.ForEach(x =>
                {
                    // if added
                    if (!dbProjectFile.Contains(x))
                    {
                        ProjectFile projectFile = context.ProjectFiles.Create();
                        projectFile.IdFile = x;
                        projectFile.IdProject = entity.Id;
                        projectFile.IdUser = entity.ProjectFiles.FirstOrDefault().IdUser;
                        projectFile.DateCreated = entity.ProjectFiles.FirstOrDefault().DateCreated;
                        context.ProjectFiles.Add(projectFile);
                        projectFile.Project = context.Projects.FirstOrDefault(y => y.Id == entity.Id);
                        projectFile.AspNetUser = context.AspNetUsers.FirstOrDefault(y => y.Id == projectFile.IdUser);
                    }
                });
                dbProjectFile.ForEach(x =>
                {
                    // if deleted 
                    if (!modelProjectFile.Contains(x))
                    {
                        var filesProject = context.ProjectFiles
                                                    .FirstOrDefault(y => y.IdFile == x && y.IdProject == entity.Id);
                        context.ProjectFiles.Remove(filesProject);
                    }
                });

                //Project users
                List<string> dbUserProject = project.UserProjects.Select(x => x.IdUser).ToList();
                List<string> modelUserProject = entity.UsersProject.Select(x => x.IdUser).ToList();

                modelUserProject.ForEach(x =>
                    {
                        // if added
                        if (!dbUserProject.Contains(x))
                        {
                            UserProject userproject = context.UserProjects.Create();
                            userproject.IdUser = x;
                            userproject.IdProject = entity.Id;
                            context.UserProjects.Add(userproject);
                            userproject.Project = context.Projects.FirstOrDefault(y => y.Id == entity.Id);
                            userproject.AspNetUser = context.AspNetUsers.FirstOrDefault(y => y.Id == x);
                        }
                    });
                dbUserProject.ForEach(x =>
                    {
                        // if deleted 
                        if (!modelUserProject.Contains(x))
                        {
                            var userProject = context.UserProjects.FirstOrDefault(y => y.IdUser == x && y.IdProject == entity.Id);
                            context.UserProjects.Remove(userProject);
                        }
                    });

                context.SaveChanges();
            }
        }

        public static bool Delete(int id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                Project project = context.Projects.FirstOrDefault(x => x.Id == id);

                if (project == null)
                {
                    return false;
                }

                // do not delete project status if it is attached to any projects
                var issue = context.Issues.FirstOrDefault(x => x.IdProject == id);

                if (issue != null)
                {
                    return false;
                }

                var usersProject = context.UserProjects.Where(x => x.IdProject == id);

                if (usersProject != null)
                {
                    context.UserProjects.RemoveRange(usersProject);
                }

                context.Projects.Remove(project);

                context.SaveChanges();

                return true;
            }
        }

        public static void Reorder(int id, int order)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                Project project = context.Projects.FirstOrDefault(x => x.Id == id);

                if (project == null)
                {
                    return;
                }

                project.DisplayOrder = order;

                context.SaveChanges();
            }
        }

        public static int GetOrder()
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                int result = 1;

                Project project = context.Projects.OrderByDescending(x => x.DisplayOrder).FirstOrDefault();

                if (project != null)
                {
                    result = project.DisplayOrder + 1;
                }

                return result;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
