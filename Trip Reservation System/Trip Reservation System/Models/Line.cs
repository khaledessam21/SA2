using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trip_Reservation_System.Models
{
    public class Line
    {
        public int Id { get; set; }

        [Required(ErrorMessage="You have to enter your name")]
        [Display(Name="Line Name")]
        public String Name { get; set; }

        public string LocFrom { get; set; }

        public string LocTo { get; set; }

        [Required(ErrorMessage = "You have to enter the price of the ticket in this line")]
        public float Price { get; set; }
    }
}