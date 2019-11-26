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
        ProductAccessLayer obj = new ProductAccessLayer();
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return obj.GetProducts();
        }

        [HttpGet]
        public Product Details(int id)
        {
            return obj.GetProductData(id);
        }
    }
}
