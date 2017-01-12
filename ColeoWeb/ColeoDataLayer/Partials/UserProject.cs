using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColeoDataLayer.ModelColeo;

namespace ColeoDataLayer.ModelColeo
{
    public partial class UserProject
    {
        public static List<UserProject> GetByProjectId(int id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                return context.UserProjects.Where(d => d.IdProject == id).ToList();
            }
        }
    }
}
