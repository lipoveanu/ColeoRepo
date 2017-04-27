using AutoMapper;
using ColeoDataLayer.ModelColeo;
using ColeoDataLayer.Utils;
using ColeoWeb.Models;
using Newtonsoft.Json;
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
        public PartialViewResult List()
        {
            List<ProjectViewModel> projectList = Project.All()
                .Select(x => Mapper.Map<Project, ProjectViewModel>(x))
                .OrderBy(x => x.DisplayOrder)
                .ToList();

            return PartialView(projectList);

        }

        [HttpPost]
        public ActionResult List(List<ProjectViewModel> model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model)
                {
                    item.Reorder(item.Id.Value, item.DisplayOrder);
                }
            }

            return List();
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
            // creation of project not allowed if not logged in 
            if (!User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index");
            }

            ProjectViewModel model = new ProjectViewModel();

            model.InitializeData();

            if (id != null)
            {
                model.Id = id.Value;
                model.SetDataFromModel();
            }
            if (!ModelState.IsValid)
            {
                model.isValid = new AlertMessage(Status.Invalid.Get(), AlertType.Danger.Get(), false, 3000);
            }
            else
            {
                // set the saved alert 
                model.isValid = new AlertMessage(Status.Saved.Get(), AlertType.Success.Get());
            }

            return PartialView(model);

        }

        [HttpPost]
        public PartialViewResult Edit(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                // first get files from session (if they were added) and save them 
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
                // set the list to model so it will be saved when the project is saved
                model.Files = files;

                model.SetDataToModel();
                model.Save();
            }

            // if the model is invalid it will get the message from the get method
            return Edit(model.Id);

        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            ProjectViewModel model = new ProjectViewModel();
            AlertMessage result = model.Delete(id);

            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteFile(int id)
        {
            ProjectViewModel model = new ProjectViewModel();
            AlertMessage result = model.DeleteFile(id);

            return Json(result);
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


    }
}