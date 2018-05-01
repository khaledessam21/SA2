using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trip_Reservation_System.Models;

namespace Trip_Reservation_System.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            IEnumerable <Passenger> passengers= db.Passengers.ToList();
            return View(passengers);
        }



        //Delete Method 

        public ActionResult Delete(int id)
        {
            var passenger = db.Passengers.Single(p => p.Id == id);
            db.Passengers.Remove(passenger);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //Block specific passenger from the system
        public ActionResult Block(int id)
        {
            
                var passenger = db.Passengers.Single(p => p.Id == id);
                passenger.Block = !passenger.Block;
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        //Getting the data for accessing waalet of the paseenger
        [HttpGet]
        public ActionResult Admin_Edit_Passenger(int id)
        {
            var passenger = db.Passengers.SingleOrDefault(c => c.Id == id);

            if (passenger == null)
                return HttpNotFound();

            return View(passenger);
        }
        [HttpPost]
        public ActionResult Admin_Edit_Passenger(Passenger passenger)
        {
            if (!ModelState.IsValid)
            {
                return View("Admin_Edit_Passenger", passenger.Id);
            }
            else
            {
                    var p = db.Passengers.Single(b => b.Id == passenger.Id);
                    p.Wallet = passenger.Wallet;
                    db.SaveChanges();
                    return RedirectToAction("Index");   
            }
        }
    }
}