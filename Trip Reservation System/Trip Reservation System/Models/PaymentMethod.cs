using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trip_Reservation_System.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You Have To Enter Your Payment Method")]
        public string Name { get; set; }

    }
}