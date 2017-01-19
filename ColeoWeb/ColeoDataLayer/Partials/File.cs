using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColeoDataLayer.ModelColeo;

namespace ColeoDataLayer.ModelColeo
{
    public partial class File
    {
        public static File GetById(int id)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                File file = context.Files
                    .FirstOrDefault(x => x.Id == id);

                return file;
            }
        }

        public static int Save(File entity)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                context.Files.Add(entity);

                context.SaveChanges();

                return entity.Id;
            }
        }

        public static void Update(File entity)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                File file = context.Files.FirstOrDefault(x => x.Id == entity.Id);

                file.Name = entity.Name;
                file.LocalName = entity.LocalName;
                file.Extension = entity.Extension;

                context.SaveChanges();
            }
        }

        public static void Delete(File entity)
        {
            using (ColeoEntities context = new ColeoEntities())
            {
                context.Files.Remove(entity);

                context.SaveChanges();
            }
        }

    }
}
