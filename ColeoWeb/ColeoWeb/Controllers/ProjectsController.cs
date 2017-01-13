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

        [HttpGet]
        public PartialViewResult List()
        {
            List<ProjectViewModel> projectList = Project.All()
                .Select(x => new ProjectViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Color = x.Color,
                    Order = x.DisplayOrder,
                    IdStatus = x.IdStatus,
                    DateCreated = x.DateCreated,
                    UserCreated = x.IdUserCreated,
                })
                .OrderBy(x => x.Order)
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
            }

            return PartialView(vm);

        }

        [HttpPost]
        public PartialViewResult Edit(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetDataToModel();
                model.Save();
            }

            //model.InitializeData();
            //model.SetDataFromModel();

            return Edit(model.Id);

        }

        public bool Delete(int id)
        {
            ProjectViewModel vm = new ProjectViewModel();

            return vm.Delete(id);

        }

    }
}