using ColeoDataLayer.ModelColeo;
using ColeoWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;


namespace ColeoWeb.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult List(string order)
        {
            if (order == null)
            {
                order = "Order";
            }

            List<ProjectViewModel> projectList = Project.All()
                .Select(x => new ProjectViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Color = x.Color,
                    Order = x.DisplayOrder,
                    IdStatus = x.IdStatus,
                    IdParentProject = x.IdParentProject,
                    DateCreated = x.DateCreated,
                    IdUserCreated = x.IdUserCreated,
                    OrderStatus = x.ProjectStatus.DisplayOrder,
                    NameUserCreated = x.AspNetUser.UserName,
                    StatusName = x.ProjectStatus.Name,
                    ParentName = x.Project1 != null ? x.Project1.Name : string.Empty
                })
                .OrderBy(x => x.Order)
                .ToList();
            var propertyInfo = typeof(ProjectViewModel).GetProperty(order);


            projectList = projectList.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();

            return PartialView(projectList);

        }

        [HttpPost]
        public ActionResult List(List<ProjectViewModel> model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model)
                {
                    item.Reorder(item.Id.Value, item.Order);
                }
            }

            return List("Order");
        }

        
        public void Reorder(List<ColeoWeb.ColeoHelper.OrderItem> test)
        {
            ProjectViewModel vm = new ProjectViewModel();

            foreach (var item in test)
            {
                vm.Reorder(item.Key, item.Value);

            }
        }

        [HttpGet]
        public PartialViewResult Edit(int? id)
        {
            // creation of project status not allowed if not logged in 
            if (!User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index");
            }

            ProjectViewModel vm = new ProjectViewModel();

            vm.InitializeData();

            // edit project status
            if (id != null)
            {
                vm.Id = id.Value;
                vm.SetDataFromModel();
                vm.isValid = ModelState.IsValid;
            }

            return PartialView(vm);

        }

        [HttpPost]
        public PartialViewResult Edit(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<FileViewModel> files = Session.GetFiles((int)ColeoWeb.ColeoHelper.FileType.Project);
                if (files.Any())
                {
                    foreach (var item in files)
                    {
                        item.SetDataToModel();
                        item.Save();
                    }
                    // remove from session to prevent re-adding
                    Session.CleanFiles((int)ColeoWeb.ColeoHelper.FileType.Project);
                }
                // set the list to model
                model.Files = files;

                model.SetDataToModel();
                model.Save();
            }

            model.isValid = ModelState.IsValid;

            model.InitializeData();

            // edit project
            if (model.Id != null)
            {
                model.SetDataFromModel();
            }

            return PartialView(model);

        }

        public bool Delete(int id)
        {
            ProjectViewModel vm = new ProjectViewModel();

            return vm.Delete(id);

        }

        [HttpPost]
        public JsonResult UploadFile(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            // save files in the desired location 
            List<FileViewModel> files = new FileController().Upload(fileUpload);

            Session.SetFiles(files, (int)ColeoWeb.ColeoHelper.FileType.Project);

            // fie uploaded event assyncron true
            return Json("");
        }

        [HttpPost]
        public JsonResult DeleteFile(int id)
        {
           
            return Json("");
        }


    }
}