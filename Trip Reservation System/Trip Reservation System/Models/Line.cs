using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trip_Reservation_System.Models
{
    public class Line
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string LocFrom { get; set; }
        public string LocTo { get; set; }
        public float Price { get; set; }
    }
}