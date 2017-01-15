using ColeoDataLayer.ModelColeo;
using ColeoWeb.Models;
using System;
using System.Collections.Generic;
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
                order = "Name";
            }

            var prok = Project.All();

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
                    UserCreated = x.IdUserCreated,
                    OrderStatus = x.ProjectStatus.DisplayOrder,
                    OrderParent = x.Project1 != null ? x.Project1.Name : null
                })
                .OrderBy(x=>x.Order)
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

        public class Test
        {
            public int Key { get; set; }
            public int Value { get; set; }
        }

        public void Reorder(List<Test> test)
        {
            ProjectViewModel vm = new ProjectViewModel();

            foreach (var item in test)
            {
                vm.Reorder(item.Key, item.Value);
           
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

            return Edit(model.Id);

        }

        public bool Delete(int id)
        {
            ProjectViewModel vm = new ProjectViewModel();

            return vm.Delete(id);

        }

    }
}