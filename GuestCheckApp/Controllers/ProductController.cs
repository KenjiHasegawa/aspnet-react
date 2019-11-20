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
        [Route("api/Product/Index")]
        public IEnumerable<TblProduct> Index()
        {
            return obj.GetProducts();
        }
    }
}
