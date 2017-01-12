using ColeoDataLayer.ModelColeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColeoDataLayer.ModelColeo
{
    public partial class AspNetUser
    {
        public static AspNetUser GetById(string id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                //context.Configuration.LazyLoadingEnabled = false;
                var user = context.AspNetUsers
                    .FirstOrDefault(d => d.Id.Contains(id));

                return user;
            }
        }

        public static List<AspNetUser> All()
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                return context.AspNetUsers.ToList();
            }
        }
    }
}
