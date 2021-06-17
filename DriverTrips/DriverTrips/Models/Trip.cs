using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverTrips.Models
{
    public class Trip
    {
        public string Driver { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public float Distance { get; set; }
        public TimeSpan Duration { get; set; }
        public double Speed { get; set; }
    }
}