using LawnCare.Models;
using LawnCare.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawnCare.WebMVC.Controllers
{
    public class MowerController : Controller
    {
        // GET: Mower
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MowerService(userId);
            var model = service.GetMowers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id )
        {
            var service = CreateMowerService();
            var model = service.GetMowerById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MowerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMowerService();

            if (service.CreateMower(model))
            {
                TempData["SaveResult"] = "Your mower was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Mower could not be created.");
            return View(model);

        }

        private MowerService CreateMowerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MowerService(userId);
            return service;
        }
        public ActionResult Edit(int id)
        {
            var service = CreateMowerService();
            var detail = service.GetMowerById(id);
            var model =
                new MowerEdit
                {
                    MowerId = detail.MowerId,
                    MowerName = detail.MowerName,
                    MowerCity = detail.MowerCity,
                    MowerService = detail.MowerService,
                    MowerRate = detail.MowerRate
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MowerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MowerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateMowerService();
            if (service.UpdateMower(model))
            {
                TempData["SaveResult"] = "Your mower was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your mower could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateMowerService();
            var model = svc.GetMowerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMowerService();
            service.DeleteMower(id);

            TempData["SaveResult"] = "Your mower was deleted";
            return RedirectToAction("Index");
        }
    }
}