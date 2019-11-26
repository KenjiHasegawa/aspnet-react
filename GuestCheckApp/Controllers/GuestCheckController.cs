using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GuestCheckApp.Models;
using Newtonsoft.Json.Linq;

namespace GuestCheckApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestCheckController : ControllerBase
    {
        GuestCheckAccessLayer obj = new GuestCheckAccessLayer();
        GuestCheckProductAccessLayer objProduct = new GuestCheckProductAccessLayer();

        [HttpGet]
        // GET api/GuestCheck
        public IEnumerable<GuestCheck> Get() => obj.GetAllGuestChecks();

        [HttpGet("{id}")]
        public List<Object> Details(int id)
        {
            List<Object> result = new List<Object>();

            GuestCheck guestCheck = obj.GetGuestCheckData(id);
            result.Add(guestCheck);

            List<GuestCheckProduct> guestCheckProducts= objProduct.GetGuestCheckProducts(id);
            result.Add(guestCheckProducts);

            return result;
        }

        [HttpPost]
        [Route("api/GuestCheck/Create")]
        public int Create([FromBody]JObject postData)
        {
            
            List<GuestCheckProduct> products = postData["GuestCheckProducts"].ToObject<List<GuestCheckProduct>>();
            List<GuestCheckProduct> guestCheckProducts = new List<GuestCheckProduct>();

            GuestCheck guestCheck = postData["GuestCheck"].ToObject<GuestCheck>();

            int id = obj.AddGuestCheck(guestCheck);
            
            if (id > 0)
            {
                foreach (GuestCheckProduct elem in products) {
                    guestCheckProducts.Add(new GuestCheckProduct(){
                        GuestCheckID = id,
                        ProductID = elem.ProductID,
                        ProductQty = elem.ProductQty
                    });
                }

                return objProduct.AddGuestCheckProductList(guestCheckProducts);
            }

            return 0;
        }

        
        [HttpPut]
        [Route("api/GuestCheck/Edit")]
        public int Edit([FromBody]JObject postData)
        {
            List<GuestCheckProduct> products = postData["GuestCheckProducts"].ToObject<List<GuestCheckProduct>>();
            List<GuestCheckProduct> guestCheckProducts = new List<GuestCheckProduct>();

            GuestCheck guestCheck = postData["GuestCheck"].ToObject<GuestCheck>();

            int id = obj.UpdateGuestCheck(guestCheck);

            if (id > 0)
            {
                foreach (GuestCheckProduct elem in products)
                {
                    guestCheckProducts.Add(new GuestCheckProduct()
                    {
                        GuestCheckID = id,
                        ProductID = elem.ProductID,
                        ProductQty = elem.ProductQty
                    });
                }

                return objProduct.UpdateGuestCheckProduct(guestCheckProducts);
            }

            return 0;

        }

    }
}
