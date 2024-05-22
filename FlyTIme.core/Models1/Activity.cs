using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public Vol Vol { get; set; }
        public Aeroport FromDestination { get; set; }
        public Aeroport ToDestination { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public TimeSpan CalculateDuration()
        {
            return TimeSpan.Zero;
        }
    }
}
