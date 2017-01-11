using ColeoDataLayer.ModelColeo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ColeoWeb.Models
{
    public class ProjectViewModel 
    {

        public ProjectViewModel()
        {
            DateCreated = DateTime.Now;
            UserCreated = HttpContext.Current.User.Identity.GetUserId();
            NameUserCreated = HttpContext.Current.User.Identity.Name;
            Color = "#E8A13F";
            IdStatus = ProjectStatus.GetDefault().Id;
        }

        #region Properties 

        Project Model { get; set; }

        public int? Id { get; set; }

        [DisplayName("Name") ]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Date created")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Stauts")]
        public int IdStatus { get; set; }

        [DisplayName("Color")]
        public string Color { get; set; }

        public IEnumerable<SelectListItem> Status { get; set; }

        public string UserCreated;

        [DisplayName("User created")]
        public string NameUserCreated { get; set; }

        [DisplayName("Order")]
        public int Order { get; set; }

        #endregion Properties

        #region Methods

        public void InitializeData()
        {
            Status = ProjectStatus.All().Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToList();

        }

        public void SetDataToModel()
        {
            Model = new Project(); 

            if (Id != null)
            {
                Model.Id = Id.Value;
            }

            Model.Name = Name;
            Model.Description = Description;
            Model.DateCreated = DateCreated;
            Model.Color = Color;
            Model.IdUserCreated = UserCreated;
            Model.IdStatus = IdStatus;
        }

        public void SetDataFromModel()
        {
            Model = Project.GetById(Id.Value);

            Name = Model.Name;
            Description = Model.Description;
            DateCreated = Model.DateCreated;
            Color = Model.Color;
            UserCreated = Model.IdUserCreated;
            IdStatus = Model.IdStatus;
            NameUserCreated = Model.AspNetUser.UserName;
        }

        public void Save()
        {
            //save
            if (Id == null)
            {
                Id = Project.Save(Model);
            }
            else
            {
                Project.Update(Model);
            }
        }

        public bool Delete(int id)
        {
            return Project.Delete(id);
        }

        #endregion Methods
    }
}