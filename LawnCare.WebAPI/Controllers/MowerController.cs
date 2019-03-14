using LawnCare.Models;
using LawnCare.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LawnCare.WebAPI.Controllers
{
    public class MowerController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            MowerService mowerService = CreateMowerService();
            var mowers = mowerService.GetMowers();
            return Ok(mowers);
        }
        public IHttpActionResult Get(int id)
        {
            MowerService mowerService = CreateMowerService();
            var mower = mowerService.GetMowerById(id);
            return Ok(mower);
        }
        public IHttpActionResult Post(MowerCreate mower)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMowerService();

            if (!service.CreateMower(mower))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(MowerEdit mower)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMowerService();

            if (!service.UpdateMower(mower))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMowerService();

            if (!service.DeleteMower(id))
                return InternalServerError();
            return Ok();
        }
        private MowerService CreateMowerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var mowerService = new MowerService(userId);
            return mowerService;
        }
    }
}
