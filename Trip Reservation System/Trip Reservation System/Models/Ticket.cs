using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trip_Reservation_System.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime ReservationDay { get; set; }
        public string LocFrom { get; set; }
        public string LocTo { get; set; }
        public int BusId { get; set; }

        [Display(Name = "Time From")]
        [DataType(DataType.Time)]
        [Range(typeof(TimeSpan), "00:00", "12:00")]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan TimeFrom { get; set; }

        [Display(Name = "Time To")]
        [DataType(DataType.Time)]
        [Range(typeof(TimeSpan), "00:00", "12:00")]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan TimeTo { get; set; }

        public float TotalPrice { get; set; }
        public string PaymentType { get; set; }
        public Passenger Passenger { get; set; }
        public int PassengerId { get; set; }
        public int NumberOfseats { get; set; }

    }
}