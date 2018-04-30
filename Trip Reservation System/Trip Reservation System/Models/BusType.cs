using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trip_Reservation_System.Models
{
    public class BusType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}