using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trip_Reservation_System.Models;
using Trip_Reservation_System.ViewModels;

namespace Trip_Reservation_System.Controllers
{
    public class LinesController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        //getway to show which dataabse will be connected to 
        // GET: Lines
        public ActionResult Index()
        {
            var lines = GetLines();
            return View(lines);
        }

        //Get Lines from database 


        public IEnumerable<Line> GetLines()
        {
            var lines = db.Lines.ToList();
            return lines;
        }
        //Getting the data of New Line
        [HttpGet]
        public ActionResult AddNewLine()
        {
            var lines = db.Lines.ToList();
            Lines cm = new Lines
            {
                lines = lines
            };
            return View(cm);
        }

        //Adding the data of new line in database 
        [HttpPost]
        public ActionResult AddNewLine(Lines cm)
        {
            if (!ModelState.IsValid)
            {
                var lines = db.Lines.ToList();
                cm.lines = lines;
                return View("AddNewLine", cm);
            }

            db.Lines.Add(cm.line);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var line = db.Lines.SingleOrDefault(x => x.Id == id);
            db.Lines.Remove(line);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Details of each Line 

        public ActionResult Details(int id)
        {
            var line = GetLines().Single(c => c.Id == id);
            if (line == null)
            {
                return HttpNotFound();

            }
            return View(line);
        }


        //Update line (getting data from database)
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var line = db.Lines.SingleOrDefault(x => x.Id == id);
            var lines = db.Lines.ToList();
            Lines cm = new Lines
            {
               lines = lines,
                line = line

            };

            return View(cm);
        }


        //Update Line details in database[Post] 
        [HttpPost]
        public ActionResult Edit(Lines cm)
        {
            if (!ModelState.IsValid)
            {
                var lines = db.Lines.ToList();
                cm.lines = lines;
                return View("Edit", cm);
            }

            var customerDB = db.Lines.SingleOrDefault(X => X.Id == cm.line.Id);
            customerDB.LocFrom = cm.line.LocFrom;
            customerDB.LocTo = cm.line.LocTo;
            customerDB.Price = cm.line.Price;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}