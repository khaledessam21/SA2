using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trip_Reservation_System.Models
{
    public class Seats
    {
        public int Number { get; set; }
        public bool Availability { get; set; }
        public Bus Bus { get; set; }
        public int BusId { get; set; }
    }
}