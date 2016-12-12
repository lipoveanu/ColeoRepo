﻿using ColeoDataLayer.ModelColeo;
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
        public ActionResult Index(ProjectStatusViewModel model)
        {
            List<ProjectStatusViewModel> projectStatusList = ProjectStatu.All()
                .Select(x => new ProjectStatusViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Color = x.Color,
                        IsDefault = x.IsDefault,
                        Order = x.DisplayOrder,
                        IsInvalid = false
                    })
                    .ToList();

            if (model != null)
            {
                projectStatusList.ForEach(x =>
                {
                    if (x.Id == model.Id)
                    {
                        x.IsInvalid = model.IsInvalid;
                    }
                });
            }
            
            return View(projectStatusList);
        }

        [HttpPost]
        public ActionResult Index(List<ProjectStatusViewModel> model)
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
                return View(model);
            }
        }

        public ActionResult Edit(int? id)
        {
            // creation of project status not allowed if not logged in 
            if (!User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index");
            }

            ProjectStatusViewModel vm = new ProjectStatusViewModel();

            // edit project status
            if (id != null)
            {
                vm.Id = id.Value;
                vm.SetDataFromModel();
            }

            return PartialView(vm);

        }

        [HttpPost]
        public PartialViewResult Edit(ProjectStatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetDataToModel();
                model.Save();

                return PartialView(model);
            }
            else
            {
                return PartialView(model);
                //return RedirectToAction("Index");
            }
        }
    }
}