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
    public class ClientController : Controller
    {
        // GET: Client
        [Authorize]
        public ActionResult Index()
        {
            ClientService service = CreateClientService();
            var model = service.GetClients();

            return View(model);
        }

        private ClientService CreateClientService()
        {
            var clientId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(clientId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            if (service.CreateClient(model)) 
            {
                TempData["SaveResult"] = "Your client was created.";
                return RedirectToAction("Index");
            };
            

            ModelState.AddModelError("", "Client coud not be created.");

            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateClientService();
            var detail = service.GetClientById(id);
            var model =
                new ClientEdit
                {
                    ClientId = detail.ClientId,
                    ClientName = detail.ClientName,
                    ClientCity = detail.ClientCity,
                    ClientNeeds = detail.ClientNeeds
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ClientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateClientService();
            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateClientService();
            service.DeleteClient(id);

            TempData["SaveResult"] = "Your client was deleted";
            return RedirectToAction ("Index");
        }



    }
}