using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColeoDataLayer.ModelColeo;
using System.IO;
using System.Security.Permissions;

namespace ColeoDataLayer.ModelColeo
{
    public partial class File
    {
        // get the file path from web config
        private static string UploadPath = "D:/01 COLEO/Images/";

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

        public static bool Delete(int id, ColeoEntities context)
        {
            File file = context.Files.FirstOrDefault(x => x.Id == id);

            if (file == null)
            {
                return false;
            }

            string path = Path.Combine(UploadPath, file.Name);

            // check if the file still exists at the path registred in the DB
            if (System.IO.File.Exists(path))
            {
                // chek if you can actualy delete the file ??? permissions
                // delete the physical file
                System.IO.File.Delete(path);

                // delete from DB.
                context.Files.Remove(file);

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
