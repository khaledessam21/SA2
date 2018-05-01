using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trip_Reservation_System.Models;

namespace Trip_Reservation_System.ViewModels
{
    public class Lines
    {
        public Line line { get; set; }
        public IEnumerable<Line> lines { get; set; }
    }
}