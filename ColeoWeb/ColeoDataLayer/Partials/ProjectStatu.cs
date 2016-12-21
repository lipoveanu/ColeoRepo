using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColeoDataLayer.ModelColeo;

namespace ColeoDataLayer.ModelColeo
{
    public partial class ProjectStatu
    {
        public static List<ProjectStatu> All()
        {
            using (ColeoEntities context = new ColeoEntities() )
            {
                List<ProjectStatu> projectStatusList = context.ProjectStatus.OrderBy(d => d.DisplayOrder).ToList();

                return projectStatusList
                    .Select(d => new ProjectStatu()
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Color = d.Color,
                        DisplayOrder = d.DisplayOrder
                    })
                    .OrderBy(x=>x.DisplayOrder)
                    .ToList();
            }
        }

        public static ProjectStatu GetDefault()
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                ProjectStatu defaultProjStatus = context.ProjectStatus.FirstOrDefault(x => x.IsDefault == true);
                if (defaultProjStatus == null)
                {
                    defaultProjStatus = context.ProjectStatus.OrderBy(x => x.DisplayOrder).FirstOrDefault();
                }
                return defaultProjStatus;
            }
        }

        public static ProjectStatu GetById(int id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                ProjectStatu projectStatus = context.ProjectStatus
                                                    .FirstOrDefault(x => x.Id == id);

                return projectStatus;
            }
        }

        public static int Save(ProjectStatu entity)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                context.ProjectStatus.Add(entity);

                context.SaveChanges();

                return entity.Id;
            }
        }

        public static void Update(ProjectStatu entity)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                ProjectStatu projectStatus = context.ProjectStatus.FirstOrDefault(x => x.Id == entity.Id);

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

        public static void Delete(int id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                ProjectStatu projectStatus = context.ProjectStatus.FirstOrDefault(x => x.Id == id);

                if (projectStatus == null)
                {
                    return;
                }

                context.ProjectStatus.Remove(projectStatus);

                context.SaveChanges();
            }
        }

        public override string ToString()
        {
            return string.Format("{0};  {1};  {2};", Name, DisplayOrder.ToString(), IsDefault.ToString());
        }
    }
}
