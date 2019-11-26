using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GuestCheckApp.Models;

namespace GuestCheckApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestCheckController : ControllerBase
    {
        GuestCheckAccessLayer obj = new GuestCheckAccessLayer();
        [HttpGet]
        public IEnumerable<GuestCheck> GetAllGuestChecks()
        {
            return obj.GetAllGuestChecks();
        }

        [HttpGet]
        public GuestCheck Details(int id)
        {
            return obj.GetGuestCheckData(id);
        }

        [HttpPost]
        [Route("api/GuestCheck/Create")]
        public int Create(GuestCheck guestCheck)
        {
            return obj.AddGuestCheck(guestCheck);
        }

        
        [HttpPut]
        [Route("api/GuestCheck/Edit")]
        public int Edit(GuestCheck guestCheck)
        {
            return obj.UpdateGuestCheck(guestCheck);
        }
        [HttpDelete]
        [Route("api/GuestCheck/Delete/{id}")]
        public int Delete(int id)
        {
            return obj.DeleteGuestCheck(id);
        }
    }
}
