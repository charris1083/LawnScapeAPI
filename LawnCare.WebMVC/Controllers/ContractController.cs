using LawnCare.Models;
using LawnCare.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace LawnCare.WebMVC.Controllers
{
    public class ContractController : Controller
    {
        // GET: Contact
        [Authorize]
        public ActionResult Index()
        {
            var service = CreateContractService();
            var model = service.GetContracts();
            return View(model);
        }
        public ActionResult Create()
        {
            var clientService = CreateClientService();
            var mowerService = CreateMowerService();
            var clients = clientService.GetClients();
            var mowers = mowerService.GetMowers();

            ViewBag.ClientId = new SelectList(clients, "ClientId", "ClientName", "ClientCity");
            ViewBag.MowerId = new SelectList(mowers, "MowerId", "MowerName", "MowerRate");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateContractService();

            if (service.CreateContract(model))
            {
                TempData["SaveResult"] = "Your contract was created.";
                return RedirectToAction("Index");
            };
            return View(model);
        }

        private ContractService CreateContractService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContractService(userId);
            return service;
        }
        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }
        private MowerService CreateMowerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MowerService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateContractService();
            var model = svc.GetContractById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateContractService();
            var detail = service.GetContractById(id);
            var model =
                new ContractEdit
                {
                    ContractId = detail.ContractId,
                    ClientName = detail.ClientName,
                    MowerName = detail.MowerName,
                    ClientCity = detail.ClientCity,
                    MowerService = detail.MowerService,
                    MowerRate = detail.MowerRate,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContractEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ContractId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateContractService();
            if (service.UpdateContract(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateContractService();
            var model = svc.GetContractById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateContractService();
            service.DeleteContract(id);

            TempData["SaveResult"] = "Your client was deleted";
            return RedirectToAction("Index");
        }
    }
}