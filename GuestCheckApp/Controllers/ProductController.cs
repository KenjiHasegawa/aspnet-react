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
    public class ProductController : ControllerBase
    {
        DataAccessLayer obj = new DataAccessLayer();
        [HttpGet]
        public IEnumerable<TblProduct> Get()
        {
            return obj.GetProducts();
        }
    }
}
