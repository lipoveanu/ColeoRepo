using AutoMapper;
using ColeoDataLayer.ModelColeo;
using ColeoDataLayer.Utils;
using ColeoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColeoWeb.Controllers
{
    public class ProjectStatusController : Controller
    {
        // GET: ProjectStatus
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult List()
        {
            List<ProjectStatusViewModel> projectStatusList = ProjectStatus.All()
                .Select(x => Mapper.Map<ProjectStatus, ProjectStatusViewModel>(x))
                .OrderBy(x => x.DisplayOrder)
                .ToList();

            return PartialView(projectStatusList);

        }

        [HttpPost]
        public ActionResult List(List<ProjectStatusViewModel> model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model)
                {
                    item.SetDataToModel();
                    item.Save();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return PartialView(model);
            }
        }

        public void Reorder(List<ColeoWeb.ColeoHelper.OrderItem> test)
        {
            ProjectStatusViewModel model = new ProjectStatusViewModel();

            foreach (var item in test)
            {
                model.Reorder(item.Key, item.Value);

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

            ProjectStatusViewModel model = new ProjectStatusViewModel();

            // edit project status
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
                model.isValid = new AlertMessage(Status.Saved.Get(), AlertType.Success.Get());
            }

            return PartialView(model);

        }

        [HttpPost]
        public PartialViewResult Edit(ProjectStatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetDataToModel();
                model.Save();

            }

            return Edit(model.Id);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            ProjectStatusViewModel model = new ProjectStatusViewModel();
            AlertMessage result = model.Delete(id);

            return Json(result);

        }
    }
}