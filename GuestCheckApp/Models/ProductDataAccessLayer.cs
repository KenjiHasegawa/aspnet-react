
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GuestCheckApp.Models
{
    public class ProductDataAccessLayer
    {
        GuestCheckAppKenji_dbContext db = new GuestCheckAppKenji_dbContext();
        public IEnumerable<TblGuestCheck> GetAllProducts()
        {
            try
            {
                return db.TblGuestCheck.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new GuestCheck record     
        public int AddGuestCheck(TblGuestCheck guestCheck)
        {
            try
            {
                db.TblGuestCheck.Add(guestCheck);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar GuestCheck    
        public int UpdateGuestCheck(TblGuestCheck guestCheck)
        {
            try
            {
                db.Entry(guestCheck).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular GuestCheck    
        public TblGuestCheck GetGuestCheckData(int id)
        {
            try
            {
                TblGuestCheck guestCheck = db.TblGuestCheck.Find(id);
                return guestCheck;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular GuestCheck    
        public int DeleteGuestCheck(int id)
        {
            try
            {
                TblGuestCheck guestCheck = db.TblGuestCheck.Find(id);
                db.TblGuestCheck.Remove(guestCheck);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Get the list of Products    
        public List<TblProduct> GetProducts()
        {
            List<TblProduct> product = new List<TblProduct>();
            product = (from ProductList in db.TblProduct select ProductList).ToList();
            return product;
        }

        //To Add new GuestCheckProduct record     
        public int AddGuestCheckProduct(TblGuestCheckProduct guestCheckProduct)
        {
            try
            {
                db.TblGuestCheckProduct.Add(guestCheckProduct);
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
                TblGuestCheckProduct guestCheckProduct = db.TblGuestCheckProduct.Find(id);
                db.TblGuestCheck.Remove(guestCheckProduct);
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