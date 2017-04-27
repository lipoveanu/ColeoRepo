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
using ColeoDataLayer.Utils;
using AutoMapper;

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
        public int DisplayOrder { get; set; }

        public List<UserProjectViewModel> UsersProject { get; set; }

        public AlertMessage isValid { get; set; }

        public List<FileViewModel> Files { get; set; }

        public int IdFile { get; set; }

        #endregion Properties

        #region Methods

        public void InitializeData()
        {
            DateCreated = DateTime.Now.AddDays(-6);
            IdUserCreated = HttpContext.Current.User.Identity.GetUserId();
            NameUserCreated = HttpContext.Current.User.Identity.Name;
            Color = "#E8A13F";

            // set the status with the default one
            IdStatus = ProjectStatus.GetDefault().Id;

            // fill in dropdown for statuses
            Status = ProjectStatus.All().Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                }).ToList();

            // fill in dropdown for parent project
            Parent = Project.All().Select(d => new SelectListItem()
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();

            // get all users 
            UsersProject = Mapper.Map<List<AspNetUser>, List<UserProjectViewModel>>(AspNetUser.All());

            Files = new List<FileViewModel>();

            DisplayOrder = Project.GetOrder();
        }

        public void SetDataToModel()
        {
            Model = Mapper.Map<ProjectViewModel, Project >(this);

            if (Id != null)
            {
                Model.Id = Id.Value;
            }

            Model.UserProjects = new List<UserProject>();
            if (UsersProject != null)
            {
                UsersProject
                    .Where(x => x.IsAssigned == true)
                    .ToList()
                    .ForEach(x => Model.UserProjects.Add(new UserProject()
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

            Mapper.Map<Project, ProjectViewModel>(Model, this);

            if (Model.UserProjects.Any())
            {
                UsersProject.Where(x => Model.UserProjects.Select(y => y.IdUser).Contains(x.UserId))
                .ToList()
                .ForEach(z => z.IsAssigned = true);
            }

            if (Model.ProjectFiles != null)
            {
                Files = Model.ProjectFiles
                    .Select(x => Mapper.Map<ProjectFile,FileViewModel>(x))
                    .ToList();
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

        public AlertMessage Delete(int id)
        {
            return Project.Delete(id);
        }

        public AlertMessage DeleteFile(int id)
        {
            return Project.DeleteFile(id);
        }

        public void Reorder(int id, int order)
        {
            Project.Reorder(id, order);
        }

        #endregion Methods
    }
}