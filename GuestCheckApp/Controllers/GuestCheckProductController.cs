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
    public class GuestCheckProductController : ControllerBase
    {
        DataAccessLayer obj = new DataAccessLayer();

        [HttpGet]
        [Route("api/GuestCheckProduct/Index")]
        public IEnumerable<TblGuestCheckProduct> Index()
        {
            return obj.GetGuestCheckProducts();
        }
        [HttpPost]
        [Route("api/GuestCheckProduct/Create")]
        public int Create(TblGuestCheckProduct guestCheckProduct)
        {
            return obj.AddGuestCheckProduct(guestCheckProduct);
        }

        [HttpPut]
        [Route("api/GuestCheckProduct/Edit")]
        public int Edit(TblGuestCheckProduct guestCheckProduct)
        {
            return obj.UpdateGuestCheckProduct(guestCheckProduct);
        }
        [HttpDelete]
        [Route("api/GuestCheckProduct/Delete/{id}")]
        public int Delete(int id)
        {
            return obj.DeleteGuestCheckProduct(id);
        }
    }
}
