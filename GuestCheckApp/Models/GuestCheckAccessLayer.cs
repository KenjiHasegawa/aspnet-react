
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GuestCheckApp.Models
{
    public class GuestCheckAccessLayer
    {
        GuestCheckAppKenji_dbContext db = new GuestCheckAppKenji_dbContext();
        public IEnumerable<GuestCheck> GetAllGuestChecks()
        {
            try
            {
                return db.GuestCheck.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new GuestCheck record     
        public int AddGuestCheck(GuestCheck guestCheck)
        {
            try
            {
                db.GuestCheck.Add(guestCheck);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar GuestCheck    
        public int UpdateGuestCheck(GuestCheck guestCheck)
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
        public GuestCheck GetGuestCheckData(int id)
        {
            try
            {
                GuestCheck guestCheck = db.GuestCheck.Find(id);
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
                GuestCheck guestCheck = db.GuestCheck.Find(id);
                db.GuestCheck.Remove(guestCheck);
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