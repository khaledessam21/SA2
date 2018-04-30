using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trip_Reservation_System.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public int AvailsbleSeats { get; set; }
        public int ReservedSeats { get; set; }
        public DateTime FullDate { get; set; }
        public Bus Bus { get; set; }
        public int BusId { get; set; }
    }
}