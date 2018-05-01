using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trip_Reservation_System.Models;

namespace Trip_Reservation_System.ViewModels
{
    public class BusLineViewModel
    {
        public IEnumerable<Bus> Buses { get; set; }

        public IEnumerable<Line> Lines { get; set; }

        public IEnumerable<Day> Days { get; set; }

        public IEnumerable<BusType> BusTypes { get; set; }

        public BusType BusType { get; set; }

        public Bus Bus { get; set; }

        public Line Line { get; set; }

        // [Required(ErrorMessage = "You Have To Enter Your Trip date")]
        public Trip Trip { get; set; }

        public bool ExtraBags { get; set; }

        public IEnumerable<PaymentMethod> paymentTypes { get; set; }

        public PaymentMethod paymentType { get; set; }

        public int BID { get; set; }
    }
}