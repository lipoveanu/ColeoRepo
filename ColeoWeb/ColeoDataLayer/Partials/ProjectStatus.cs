using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColeoDataLayer.ModelColeo;

namespace ColeoDataLayer.ModelColeo
{
    public partial class ProjectStatus
    {
        public static List<ProjectStatus> All()
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                List<ProjectStatus> projectStatusList = context.ProjectStatuses.OrderBy(d => d.DisplayOrder).ToList();

                return projectStatusList
                    .Select(d => new ProjectStatus()
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Color = d.Color,
                        DisplayOrder = d.DisplayOrder
                    })
                    .OrderBy(x => x.DisplayOrder)
                    .ToList();
            }
        }

        public static ProjectStatus GetDefault()
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                ProjectStatus defaultProjStatus = context.ProjectStatuses.FirstOrDefault(x => x.IsDefault == true);
                if (defaultProjStatus == null)
                {
                    defaultProjStatus = context.ProjectStatuses.OrderBy(x => x.DisplayOrder).FirstOrDefault();
                }
                return defaultProjStatus;
            }
        }

        public static ProjectStatus GetById(int id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                // do this to avoid error at json.encode
                context.Configuration.LazyLoadingEnabled = false;
                ProjectStatus projectStatus = context.ProjectStatuses
                                                    .FirstOrDefault(x => x.Id == id);

                return projectStatus;
            }
        }

        public static void UpdateDefault(ColeoEntities context, ProjectStatus entity)
        {
            List<ProjectStatus> listAllOthers = context.ProjectStatuses.Where(x => x.Id != entity.Id).ToList();

            if (listAllOthers.Any())
            {
                if (entity.IsDefault)
                {
                    listAllOthers.ForEach(x => x.IsDefault = false);
                }
                else
                {
                    // if i uncheck the default status choose random stauts and set as default
                    if (!listAllOthers.Any(x=>x.IsDefault == true))
                    {
                        context.ProjectStatuses.FirstOrDefault(x => x.Id != entity.Id).IsDefault = true;
                    }
                }
            }
            else
            {
                //if this is the first status force it to be default
                entity.IsDefault = true;
            }
           
        }

        public static int Save(ProjectStatus entity)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                context.ProjectStatuses.Add(entity);

                ProjectStatus.UpdateDefault(context, entity);

                context.SaveChanges();

                return entity.Id;
            }
        }


        public static void Update(ProjectStatus entity)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                ProjectStatus projectStatus = context.ProjectStatuses.FirstOrDefault(x => x.Id == entity.Id);

                if (projectStatus == null)
                {
                    return;
                }

                // set properties
                projectStatus.Name = entity.Name;
                projectStatus.Color = entity.Color;
                projectStatus.DisplayOrder = entity.DisplayOrder;
                projectStatus.IsDefault = entity.IsDefault;

                ProjectStatus.UpdateDefault(context, entity);

                context.SaveChanges();
            }
        }

        public static bool Delete(int id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                ProjectStatus projectStatus = context.ProjectStatuses.FirstOrDefault(x => x.Id == id);

                if (projectStatus == null)
                {
                    return false;
                }

                // do not delete project status if it is attached to any projects
                var project = context.Projects.FirstOrDefault(x => x.IdStatus == id);

                if (project != null)
                {
                    return false;
                }

                // if the default project status is deleted, assign first other
                if (projectStatus.IsDefault)
                {
                    ProjectStatus defaultProjectStatus = context.ProjectStatuses.FirstOrDefault(x => x.Id != id);

                    if (defaultProjectStatus != null)
                    {
                        defaultProjectStatus.IsDefault = true;
                    }
                }

                context.ProjectStatuses.Remove(projectStatus);

                context.SaveChanges();

                return true;
            }
        }

        public override string ToString()
        {
            return string.Format("{0};  {1};  {2};", Name, DisplayOrder.ToString(), IsDefault.ToString());
        }
    }
}
