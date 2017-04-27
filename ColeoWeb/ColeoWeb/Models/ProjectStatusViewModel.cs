using AutoMapper;
using ColeoDataLayer.ModelColeo;
using ColeoDataLayer.Utils;
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
        public int DisplayOrder { get; set; }

        public AlertMessage isValid { get; set; }

        #endregion Properties

        #region Methods

        public void SetDataToModel()
        {
            Model = Mapper.Map<ProjectStatusViewModel, ProjectStatus>(this);

            if (Id != null)
            {
                Model.Id = Id.Value;
            }
        }

        public void SetDataFromModel()
        {
            Model = ProjectStatus.GetById(Id.Value);

            Mapper.Map<ProjectStatus, ProjectStatusViewModel>(Model, this); 
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

        public AlertMessage Delete(int id)
        {
            return ProjectStatus.Delete(id);
        }

        public void Reorder(int id, int order)
        {
            ProjectStatus.Reorder(id, order);
        }

        #endregion Methods

        
    }
}