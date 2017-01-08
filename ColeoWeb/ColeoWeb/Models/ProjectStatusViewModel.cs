using ColeoDataLayer.ModelColeo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColeoWeb.Models
{
    public class ProjectStatusViewModel
    {
        public ProjectStatusViewModel()
        {
            Color = "#E8A13F";
        }

        #region Properties

        public ProjectStatus Model { get; set; }

        [Key]
        public int? Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Color")]
        public string Color { get; set; }

        [DisplayName("Default stauts")]
        public bool IsDefault { get; set; }

        [DisplayName("Order")]
        public int Order { get; set; }

        public bool IsInvalid { get; set; }

        #endregion Properties

        #region Methods

        public void SetDataToModel()
        {
            Model = new ProjectStatus();

            if (Id != null)
            {
                Model.Id = Id.Value;
            }

            Model.Name = Name;
            Model.Color = Color;
            Model.IsDefault = IsDefault;
            Model.DisplayOrder = Order;
        }

        public void SetDataFromModel()
        {
            Model = ProjectStatus.GetById(Id.Value);

            Name = Model.Name;
            Color = Model.Color;
            IsDefault = Model.IsDefault;
            Order = Model.DisplayOrder;
            IsInvalid = false;
        }

        public void Save()
        {
            if (Id == null)
            {
                Id = ProjectStatus.Save(Model);
            }
            else
            {
                ProjectStatus.Update(Model);
            }
        }

        public bool Delete(int id)
        {
            return ProjectStatus.Delete(id);
        }

        #endregion Methods
    }
}