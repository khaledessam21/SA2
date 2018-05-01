using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trip_Reservation_System.Models;
using Trip_Reservation_System.ViewModels;

namespace Trip_Reservation_System.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        ApplicationDbContext DB = new ApplicationDbContext();

        public ActionResult Index()
        {

            var Buses = DB.Buses.ToList();
            var Lines = DB.Lines.ToList();

            BusLineViewModel blvm = new BusLineViewModel
            {
                Lines = Lines,
                Buses = Buses

            };
            return View(blvm);

        }



        public ActionResult Details(int id)
        {
            var Bus = DB.Buses.SingleOrDefault(c => c.Id == id);
            var Line = DB.Lines.SingleOrDefault(x => x.Id == Bus.LineId);

            if (Bus == null)
                return HttpNotFound();
            BusLineViewModel blvm = new BusLineViewModel
            {
                Line = Line,
                Bus = Bus

            };
            return View(blvm);
        }



        [HttpGet]
        public ActionResult AddBus()
        {
            var Lines = DB.Lines.ToList();
            var Days = DB.Days.ToList();
            var BusTypes = DB.BusTypes.ToList();

            BusLineViewModel blvm = new BusLineViewModel
            {
                Lines = Lines,
                Days = Days,
                BusTypes = BusTypes
            };
            return View(blvm);
        }

        [HttpPost]
        public ActionResult AddBus(BusLineViewModel blvm)
        {
            if (!ModelState.IsValid)
            {
                var Lines = DB.Lines.ToList();
                var Days = DB.Days.ToList();
                var BusTypes = DB.BusTypes.ToList();
                blvm.Lines = Lines;
                blvm.Days = Days;
                blvm.BusTypes = BusTypes;
                return View("AddBus", blvm);
            }
            else
            {
                DB.Buses.Add(blvm.Bus);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Bus = DB.Buses.ToList().SingleOrDefault(c => c.Id == id);

            var Lines = DB.Lines.ToList();
            BusLineViewModel blvm = new BusLineViewModel
            {
                Bus = Bus,
                Lines = Lines
            };
            return View(blvm);
        }
        [HttpPost]
        public ActionResult Edit(BusLineViewModel blvm)
        {
            var lines = DB.Lines.ToList();
            if (!ModelState.IsValid)
            {
                blvm.Lines = lines;
                return View("Edit", blvm);
            }
            var Bus = DB.Buses.Single(c => c.Id == blvm.Bus.Id);
            Bus.DriverName = blvm.Bus.DriverName;
            Bus.LineId = blvm.Bus.LineId;
            Bus.TimeFrom = blvm.Bus.TimeFrom;
            Bus.TimeTo = blvm.Bus.TimeTo;
            Bus.NumberOfSeats = blvm.Bus.NumberOfSeats;

            DB.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Bus = DB.Buses.Single(c => c.Id == id);
            DB.Buses.Remove(Bus);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}