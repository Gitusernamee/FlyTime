using System;

namespace FlyTime.Core.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public Flight Flight { get; set; }
        public Airport FromDestination { get; set; }
        public Airport ToDestination { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan CalculateDuration() 
        {
   
        }
    }
}
