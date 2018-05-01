using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;//email
using System.Web.Mvc;
using Trip_Reservation_System.Models;

namespace Trip_Reservation_System.Controllers
{
    public class PassengerController : Controller
    {
        public int sessid;
        ApplicationDbContext DB = new ApplicationDbContext();
        // GET: Passenger


        /* public ActionResult Index()
         {



             return View(DB.Passengers.ToList());
         }*/
        public ActionResult resetPassword()
        {

            return View();
        }

        /*  public ActionResult resetPassword()
          {
              Random rand = new Random((int)DateTime.Now.Ticks);
              int RandomNumber;
              RandomNumber = rand.Next(100000, 999999);
              SendMail()
              return View();
          }*/

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Passenger psg)
        {
            var SeachData = DB.Passengers.Where(x => x.UserName.Equals(psg.UserName)).SingleOrDefault();
            if (SeachData == null)
            {
                if (ModelState.IsValid)
                {
                    DB.Passengers.Add(psg);
                    DB.SaveChanges();
                    string x = psg.Name;
                    SendMail(psg, x);
                    ModelState.Clear();
                    ViewBag.text = psg.Name + " registered sucessfully";
                }
            }
            else { ViewBag.usernamevalid = "usrname is taken"; }

            return View();

        }


        public void SendMail(Passenger psg, string x)
        {
            WebMail.SmtpServer = "smtp.gmail.com";
            //gmail port to send emails  
            WebMail.SmtpPort = 587;
            WebMail.SmtpUseDefaultCredentials = true;
            //sending emails with secure protocol  
            WebMail.EnableSsl = true;
            //EmailId used to send emails from application  
            WebMail.UserName = "khaaledessaam@gmail.com";
            WebMail.Password = "khaled18";

            //Sender email address.  
            WebMail.From = "khaaledessaam@gmail.com";

            //Send email  

            WebMail.Send(psg.Email, "hello" + x, "hello man how are you");




        }













        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Passenger psg)
        {
            /* if (psg.UserName.Equals("admin") && psg.Password.Equals("admin"))
             {
                 Session["AdminID"] = "Admin";
                 return RedirectToAction("AdminPanel");
             }
             else
             {*/
            var user = DB.Passengers.Where(u => u.UserName == psg.UserName && u.Password == psg.Password).FirstOrDefault();
            if (user.Block == true)
            {
                ViewBag.text = psg.Name + " your account is disabled";
            }
            else
            {
                if (user.IsAdmin == true && user != null && user.Block == false)
                {
                    Session["AdminID"] = "Admin";
                    return RedirectToAction("AdminPanel");
                }
                else
                {
                    if (user != null)
                    {
                        Session["PassengerID"] = user.Id.ToString();
                        Session["UserName"] = psg.UserName.ToString();
                        //  sessid = user.Id;
                        return RedirectToAction("LoggedIn");
                    }
                    else { ModelState.AddModelError("", "username or password is wrong"); }
                }
            }
            return View();
        }
        //[Authorize]
        public ActionResult LoggedIn()
        {
            if (Session["PassengerID"] != null)
            {
                return View();
            }
            else { return RedirectToAction("Login"); }

        }
        public ActionResult AdminPanel()
        {
            if (Session["AdminID"] != null)
            {
                return View();
            }
            else { return RedirectToAction("Login"); }

        }


        public JsonResult CheckUsernameAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = DB.Passengers.Where(x => x.UserName.Equals(userdata)).SingleOrDefault();
            if (SeachData != null)
            {

                return Json(1);
            }
            else
            {

                return Json(0);
            }

        }
        public JsonResult CheckUserEmailAvailability(string userdata1)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = DB.Passengers.Where(x => x.Email.Equals(userdata1)).SingleOrDefault();
            if (SeachData != null)
            {

                return Json(1);
            }
            else
            {

                return Json(0);
            }

        }

        public ActionResult addLine()
        {
            if (Session["AdminID"] != null)
            {
                return View();
            }
            else { return RedirectToAction("Login"); }
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult CancelReservation(int id)

        {
            // int var2 =sessid;
            //   int y = 1;
            //  Session["PassengerID"]=y;
            // int y = Convert.ToInt32(Session["PassengerID"].ToString());
            //  Console.WriteLine(y);
            if (Session["PassengerID"] != null)
            {
                var usertickets = DB.Ticket.ToList().Where(x => x.PassengerId == id/* Convert.ToInt32(Session["PassengerID"])*/);
                return View(usertickets);
            }
            else { return RedirectToAction("Login"); }
            //int id = 1;
            //Convert.ToInt32(Session["PassengerID"])
        }

        public ActionResult Cancel(int NumberOfseats, DateTime date, int BusID, int UserId, float TotalPrice)
        {
            var trip = DB.Trips.SingleOrDefault(X => X.BusId == BusID && X.FullDate == date);
            trip.AvailsbleSeats = trip.AvailsbleSeats + NumberOfseats;
            trip.ReservedSeats = trip.ReservedSeats - NumberOfseats;
            DB.SaveChanges();

            var UserWallet = DB.Passengers.SingleOrDefault(X => X.Id == UserId);
            UserWallet.Wallet = UserWallet.Wallet + TotalPrice;
            DB.SaveChanges();
            return RedirectToAction("CancelReservation");
        }
    }
}