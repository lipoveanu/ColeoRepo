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
                return context.ProjectStatus.ToList().Select(d => new ProjectStatu()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Color = d.Color
                }).ToList();
            }
        }

        public static ProjectStatu GetDefault()
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                ProjectStatu defaultProjStatus = context.ProjectStatus.FirstOrDefault(x => x.IsDefault == true);
                if (defaultProjStatus == null)
                {
                    //TODO : implement column for order 
                    defaultProjStatus = context.ProjectStatus.OrderBy(x => x.Id).FirstOrDefault();
                }
                return defaultProjStatus;
            }
        }
    }
}
