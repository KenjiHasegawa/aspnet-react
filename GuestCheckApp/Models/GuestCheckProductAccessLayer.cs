
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GuestCheckApp.Models
{
    public class GuestCheckProductAccessLayer
    {
        GuestCheckAppKenji_dbContext db = new GuestCheckAppKenji_dbContext();
        
        //To Get the list of GuestCheckProducts of GuestCheck 
        public List<GuestCheckProduct> GetGuestCheckProducts(int guestCheckID)
        {
            List<GuestCheckProduct> product = new List<GuestCheckProduct>();
            product = db.GuestCheckProduct.Where(a => a.GuestCheckId == guestCheckID).ToList();
            return product;
        }

        //To Add new GuestCheckProduct record     
        public int AddGuestCheckProductList(List<GuestCheckProduct> guestCheckProduct)
        {
            try
            {
                foreach (GuestCheckProduct product in guestCheckProduct)
                {
                    db.GuestCheckProduct.Add(product);
                }
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar GuestCheckProduct    
        public int UpdateGuestCheckProduct(GuestCheckProduct guestCheckProduct)
        {
            try
            {
                db.Entry(guestCheckProduct).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular GuestCheckProduct    
        public int DeleteGuestCheckProduct(int id)
        {
            try
            {
                GuestCheckProduct guestCheckProduct = db.GuestCheckProduct.Find(id);
                db.GuestCheckProduct.Remove(guestCheckProduct);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}