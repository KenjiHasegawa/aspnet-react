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
        GuestCheckProductAccessLayer obj = new GuestCheckProductAccessLayer();

        [HttpGet]
        public IEnumerable<GuestCheckProduct> Get(int guestCheckID)
        {
            return obj.GetGuestCheckProducts(guestCheckID);
        }

        [HttpPost]
        public int Create(List<GuestCheckProduct> guestCheckProduct)
        {
            return obj.AddGuestCheckProductList(guestCheckProduct);
        }

        [HttpPut]
        public int Edit(GuestCheckProduct guestCheckProduct)
        {
            return obj.UpdateGuestCheckProduct(guestCheckProduct);
        }
        [HttpDelete]
        public int Delete(int id)
        {
            return obj.DeleteGuestCheckProduct(id);
        }
    }
}
