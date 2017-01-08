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
                ProjectStatus projectStatus = context.ProjectStatuses
                                                    .FirstOrDefault(x => x.Id == id);

                return projectStatus;
            }
        }

        public static int Save(ProjectStatus entity)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                context.ProjectStatuses.Add(entity);

                ////get max order
                //int maxOrder = 0;
                //maxOrder = context.ProjectStatuses.Max(d => d.DisplayOrder);
                //entity.DisplayOrder = maxOrder++;

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

                var project = context.Projects.FirstOrDefault(x => x.IdStatus == id);

                if (project != null)
                {
                    return false;
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
