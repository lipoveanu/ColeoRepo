using ColeoDataLayer.ModelColeo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace ColeoWeb.Models
{
    public class ProjectViewModel
    {

        public ProjectViewModel()
        {

        }

        #region Properties

        public Project Model { get; set; }

        [Key]
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

        public IEnumerable<SelectListItem> Status { get; set; }

        public string StatusName { get; set; }

        public int OrderStatus { get; set; }

        [DisplayName("Color")]
        public string Color { get; set; }

        [DisplayName("Parent")]
        public int? IdParentProject { get; set; }

        public string ParentName { get; set; }

        public IEnumerable<SelectListItem> Parent { get; set; }

        public string IdUserCreated { get; set; }

        [DisplayName("Created by")]
        public string NameUserCreated { get; set; }

        [DisplayName("Order")]
        public int Order { get; set; }

        public List<UserProjectViewModel> UsersProject { get; set; }

        public bool isValid { get; set; }

        public List<FileViewModel> Files { get; set; }

        #endregion Properties

        #region Methods

        public void InitializeData()
        {
            DateCreated = DateTime.Now.AddDays(-6);
            IdUserCreated = HttpContext.Current.User.Identity.GetUserId();
            NameUserCreated = HttpContext.Current.User.Identity.Name;
            Color = "#E8A13F";
            IdStatus = ProjectStatus.GetDefault().Id;

            Status = ProjectStatus.All().Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToList();

            Parent = Project.All().Select(d => new SelectListItem()
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

            Order = Project.GetOrder();
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
            Model.IdUserCreated = IdUserCreated;
            Model.IdStatus = IdStatus;
            Model.DisplayOrder = Order;
            Model.IdParentProject = IdParentProject;

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

            Model.ProjectFiles = new List<ProjectFile>();
            if (Files != null)
            {
                Model.ProjectFiles = Files.Select(d => new ProjectFile()
                {
                    IdFile = d.Id.Value,
                    IdUser = IdUserCreated,
                    DateCreated = DateTime.Now
                }).ToList();
            }
        }

        public void SetDataFromModel()
        {
            Model = Project.GetById(Id.Value);

            Name = Model.Name;
            Description = Model.Description;
            DateCreated = Model.DateCreated;
            Color = Model.Color;
            IdUserCreated = Model.IdUserCreated;
            IdStatus = Model.IdStatus;
            Order = Model.DisplayOrder;
            IdParentProject = Model.IdParentProject;
            NameUserCreated = Model.AspNetUser.UserName;
            StatusName = Model.ProjectStatus.Name;
            ParentName = Model.Project1 != null ? Model.Project1.Name : string.Empty;

            if (Model.UsersProject.Any())
            {
                UsersProject.Where(x => Model.UsersProject.Select(y => y.IdUser).Contains(x.UserId))
                .ToList()
                .ForEach(z => z.IsAssigned = true);
            }

            if (Model.ProjectFiles != null)
            {
                Files = Model.ProjectFiles.Select(d => new FileViewModel()
                {
                    Id = d.IdFile,
                    Name = d.File.Name,
                    LocalName = d.File.LocalName,
                    Extension = d.File.Extension
                }).ToList();
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