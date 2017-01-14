using ColeoDataLayer.ModelColeo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ColeoWeb.Models
{
    public class ProjectViewModel
    {

        public ProjectViewModel()
        {
            DateCreated = DateTime.Now.AddDays(-6);
            UserCreated = HttpContext.Current.User.Identity.GetUserId();
            NameUserCreated = HttpContext.Current.User.Identity.Name;
            Color = "#E8A13F";
            IdStatus = ProjectStatus.GetDefault().Id;
        }

        #region Properties

        Project Model { get; set; }

        public int? Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        [DisplayName("Date")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Stauts")]
        public int IdStatus { get; set; }

        [DisplayName("Color")]
        public string Color { get; set; }

        public IEnumerable<SelectListItem> Status { get; set; }

        public string UserCreated;

        [DisplayName("Created by")]
        public string NameUserCreated { get; set; }

        [DisplayName("Order")]
        public int Order { get; set; }

        public List<UserProjectViewModel> UsersProject { get; set; }

        #endregion Properties

        #region Methods

        public void InitializeData()
        {
            Status = ProjectStatus.All().Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToList();

            UsersProject = new List<UserProjectViewModel>();
            UsersProject
                .AddRange(AspNetUser.All().Select(y => new UserProjectViewModel()
            {
                UserId = y.Id,
                IsAssigned = false
            }).ToList());

            UsersProject.ForEach(x => x.InitializeData());

            

            Order = 1;
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
            Model.DisplayOrder = Order;

            Model.UsersProject = new List<UserProject>();
            if (UsersProject != null)
            {
                UsersProject
                    .Where(x => x.IsAssigned == true)
                    .ToList()
                    .ForEach(x => Model.UsersProject.Add(new UserProject()
                    {
                        IdUser = x.UserId
                        //IdProject = Id.Value
                    }));
            }

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
            Order = Model.DisplayOrder;

            if (Model.UsersProject.Any())
            {
                UsersProject.Where(x => Model.UsersProject.Select(y => y.IdUser).Contains(x.UserId))
                .ToList()
                .ForEach(z => z.IsAssigned = true);
            }

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

        public void Reorder(int id, int order)
        {
            Project.Reorder(id, order);
        }

        #endregion Methods
    }
}