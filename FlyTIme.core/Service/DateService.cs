using System.Collections.Generic;

namespace FlyTime.Core.Models
{
    public class Pilot
    {
        public int Id { get; set; }
        public string Matricule { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
