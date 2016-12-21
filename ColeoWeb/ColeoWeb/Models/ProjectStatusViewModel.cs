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

        public ProjectStatu Model { get; set; }

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
            Model = new ProjectStatu();

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
            Model = ProjectStatu.GetById(Id.Value);

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
                Id = ProjectStatu.Save(Model);
            }
            else
            {
                ProjectStatu.Update(Model);
            }
        }

        public void Delete(int id)
        {
            ProjectStatu.Delete(id);
        }

        #endregion Methods
    }
}