﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ColeoDataLayer.Utils;

namespace ColeoDataLayer.ModelColeo
{
    public partial class Project
    {
        #region Properties

        //public List<UserProject> UsersProject { get; set; }

        #endregion Properties

        public static List<Project> All()
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                return context.Projects
                    .Include(d => d.AspNetUser)
                    .Include(d => d.UserProjects)
                    .Include(d => d.ProjectStatus)
                    .Include(d => d.Project1)
                    .Include(d => d.ProjectFiles.Select(x => x.File))
                    .Include(d => d.File)
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
                    .Include(d => d.ProjectStatus)
                    .Include(d => d.Project1)
                    .Include(d => d.ProjectFiles.Select(x => x.File))
                    .Include(d => d.File)
                    .FirstOrDefault(d => d.Id == id);


                project.UserProjects = project.UserProjects.ToList();

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

                //Status
                ProjectStatus projectStatus = context.ProjectStatuses.FirstOrDefault(x => x.Id == entity.IdStatus);
                if (projectStatus != null)
                {
                    project.ProjectStatus = projectStatus;
                }

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

                //File
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
                //dbProjectFile.ForEach(x =>
                //{
                //    // if deleted 
                //    if (!modelProjectFile.Contains(x))
                //    {
                //        var filesProject = context.ProjectFiles
                //                                    .FirstOrDefault(y => y.IdFile == x && y.IdProject == entity.Id);
                //        context.ProjectFiles.Remove(filesProject);
                //    }
                //});

                //Project users
                List<string> dbUserProject = project.UserProjects.Select(x => x.IdUser).ToList();
                List<string> modelUserProject = entity.UserProjects.Select(x => x.IdUser).ToList();

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

        
        public static AlertMessage Delete(int id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                Project project = context.Projects.FirstOrDefault(x => x.Id == id);

                // if id project not found
                if (project == null)
                {
                    return new AlertMessage(Status.NotFound.Get(), AlertType.Danger.Get(), false, 3000);
                }

                // do not delete project if it is attached as parent project to any other project
                var parentProject = context.Projects.FirstOrDefault(x => x.IdParentProject == id);
                if (parentProject != null)
                {
                    return new AlertMessage(Status.ProjectAttachedToProject.Get(), AlertType.Danger.Get(), false, 3000);
                }

                // do not delete project if attached to issue
                var issueProject = context.Issues.FirstOrDefault(x => x.IdProject == id);
                if (issueProject != null)
                {
                    return new AlertMessage(Status.ProjectAttatchedToIssue.Get(), AlertType.Danger.Get(), false, 3000);
                }

                // delete all users attached to project
                var usersProject = context.UserProjects.Where(x => x.IdProject == id);
                if (usersProject != null)
                {
                    context.UserProjects.RemoveRange(usersProject);
                }

                // delete files attached to project
                var filesProject = context.ProjectFiles.Where(x => x.IdProject == id);
                if (filesProject.Any())
                {
                    foreach (var item in filesProject)
                    {
                        // if the file is deleted phisicaly
                        if (File.Delete(item.IdFile, context))
                        {
                            context.ProjectFiles.Remove(item);
                        }
                    }
                }

                context.Projects.Remove(project);

                context.SaveChanges();

                return new AlertMessage(Status.Deleted.Get(), AlertType.Success.Get()); 
            }
        }

        public static AlertMessage DeleteFile(int id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                // if file id not found
                var fileProject = context.ProjectFiles.FirstOrDefault(x => x.IdFile == id);
                if (fileProject == null)
                {
                    return new AlertMessage(Status.NotFound.Get(), AlertType.Danger.Get(), false, 3000);
                }

                // if the file is deleted phisicaly then delete it from the DB
                // send the context to delete the file from Files table before deleting it's reference in the ProjectFiles table
                // make only one savechanges 
                if (File.Delete(fileProject.IdFile, context))
                {
                    context.ProjectFiles.Remove(fileProject);
                    context.SaveChanges();

                    return new AlertMessage(Status.Deleted.Get(), AlertType.Success.Get()); 
                }
                else
                {
                    return new AlertMessage(Status.FileNotOnDisk.Get(), AlertType.Danger.Get(), false, 3000);
                }
                
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
