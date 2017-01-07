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
        public static List<Project> All()
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                return context.Projects.ToList();
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
                Project project = context.Projects
                    .Include(d => d.AspNetUser)
                    .FirstOrDefault(d => d.Id == id);

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

                //User created
                AspNetUser userCreated = context.AspNetUsers.FirstOrDefault(x => x.Id == entity.IdUserCreated);
                if (userCreated != null)
                {
                    entity.AspNetUser = userCreated;
                }

                //to do save project users

                context.SaveChanges();

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

                //Project status
                ProjectStatus projectStatus = context.ProjectStatuses.FirstOrDefault(x => x.Id == entity.IdStatus);
                if (projectStatus != null)
                {
                    project.ProjectStatus = projectStatus;
                }

                //User created
                AspNetUser userCreated = context.AspNetUsers.FirstOrDefault(x => x.Id == entity.IdUserCreated);
                if (userCreated != null)
                {
                    project.AspNetUser = userCreated;
                }

                //set properties
                project.Name = entity.Name;
                project.Description = entity.Description;
                project.DateCreated = entity.DateCreated;
                project.Color = entity.Color;

                //Project users
                List<string> dbUserProject = project.UserProjects.Select(x => x.IdUser).ToList();
                List<string> modelUserProject = entity.UserProjects.Select(x => x.IdUser).ToList();

                modelUserProject.ForEach(x =>
                    {
                        // if added
                        if (!dbUserProject.Contains(x))
                        {
                            UserProject userproject = context.UserProjects.Create();
                            context.UserProjects.Add(userproject);
                            userproject.Project = context.Projects.FirstOrDefault(y => y.Id == entity.Id);
                            userproject.AspNetUser = context.AspNetUsers.FirstOrDefault(y => y.UserName == x);
                        }
                    }
                    );
                dbUserProject.ForEach(x =>
                    {
                        // if deleted 
                        if (!modelUserProject.Contains(x))
                        {
                            var userProject = context.UserProjects.FirstOrDefault(y => y.AspNetUser.UserName == x && y.IdProject == entity.Id);
                            context.UserProjects.Remove(userProject);
                        }
                    }
                    );

                context.SaveChanges();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
