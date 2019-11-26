
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GuestCheckApp.Models
{
    public class ProductAccessLayer
    {
        GuestCheckAppKenji_dbContext db = new GuestCheckAppKenji_dbContext();
        
        //To Get the list of Products    
        public List<Product> GetProducts()
        {
            List<Product> product = new List<Product>();
            product = (from ProductList in db.Product select ProductList).ToList();
            return product;
        }

        //To Get the Product
        public Product GetProductData(int id)
        {
            try
            {
                Product product = db.Product.Find(id);
                return product;
            }
            catch
            {
                throw;
            }
        }

    }
}