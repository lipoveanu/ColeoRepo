using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ColeoDataLayer.ModelColeo;

namespace ColeoWeb.Models
{
    public class FileViewModel
    {
        #region Properties 

        public File Model { get; set; }

        public int? Id { get; set; }

        public string LocalName { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        #endregion Properties

        #region Methods

        public void SetDataFromModel()
        {
            File file = File.GetById(Id.Value);

            if (file == null)
            {
                return;
            }
 
            LocalName = file.LocalName;
            Name = file.Name;
            Extension = file.Extension;

        }

        public void SetDataToModel()
        {
            Model = new File();

            if (Id != null)
            {
                Model.Id = Id.Value;    
            }

            Model.LocalName = LocalName;
            Model.Name = Name;
            Model.Extension = Extension;
        }

        public void Save()
        {
            if (Id == null)
            {
                
                Id = File.Save(Model);
            }
            else
            {
                File.Update(Model);
            }
        }

        #endregion Methods
    }
}