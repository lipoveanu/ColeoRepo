using ColeoDataLayer.ModelColeo;
using ColeoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Edit(int? id)
        {
            // creation of project not allowed if not logged in 
            if (!User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index");
            }

            ProjectViewModel vm = new ProjectViewModel();
            vm.InitializeData();

            // edit project
            if (id != null)
            {
                vm.Id = id.Value;
                vm.SetDataFromModel();
            }
            
            return View(vm);

        }

        [HttpPost]
        public ActionResult Edit(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetDataToModel();
                model.Save();

                return RedirectToAction("Edit", new { id = model.Id });
            }
            else
            {
                model.InitializeData();

                return View(model);
            }
        }
    }
}