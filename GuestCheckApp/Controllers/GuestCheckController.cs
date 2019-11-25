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
        DataAccessLayer obj = new DataAccessLayer();
        [HttpGet]
        public IEnumerable<TblGuestCheck> Get()
        {
            return obj.GetAllGuestChecks();
        }
        [HttpPost]
        [Route("api/GuestCheck/Create")]
        public int Create(TblGuestCheck guestCheck)
        {
            return obj.AddGuestCheck(guestCheck);
        }
        [HttpGet]
        [Route("api/GuestCheck/Details/{id}")]
        public TblGuestCheck Details(int id)
        {
            return obj.GetGuestCheckData(id);
        }
        [HttpPut]
        [Route("api/GuestCheck/Edit")]
        public int Edit(TblGuestCheck guestCheck)
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
