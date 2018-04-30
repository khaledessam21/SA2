using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trip_Reservation_System.Models
{
    public class Bus
    {
        public int Id { get; set; }

        [Display(Name = "Driver Name")]
        [Required(ErrorMessage = "You Have To Enter Your DriverName")]
        public string DriverName { get; set; }


        [Display(Name = " Number Of Seats")]
        [Required(ErrorMessage = "You Have To Enter Your NumberOfSeats")]
        public int NumberOfSeats { get; set; }

        [Display(Name = "Time From")]
        [DataType(DataType.Time)]
        [Range(typeof(TimeSpan), "00:00", "12:00")]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        [Required(ErrorMessage = "You Have To Enter Your TimeFrom")]
        public TimeSpan TimeFrom { get; set; }

        [Display(Name = "Time To")]
        [DataType(DataType.Time)]
        [Range(typeof(TimeSpan), "00:00", "12:00")]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        [Required(ErrorMessage = "You Have To Enter Your TimeTo")]
        public TimeSpan TimeTo { get; set; }

        public Line Line { get; set; }

        [Required(ErrorMessage = "You Have To Enter Your LineId")]
        [Display(Name = "Line Name")]
        public int LineId { get; set; }


        [Required(ErrorMessage = "You Have To Enter Your Day")]
        [Display(Name = "Day")]
        public DayOfWeek Day { get; set; }

        public BusType BusType { get; set; }

        [Required(ErrorMessage = "You Have To Enter Your BusType")]
        [Display(Name = "BusType")]
        public int BusTypeId { get; set; }
    }
}