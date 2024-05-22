using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Models
{
    public class Vol
    {
        public int Id { get; set; }
        public Pilot Pilot { get; set; }
        public List<Activity> Activities { get; set; }


        public string DeterminerTypeVol()
        {
            // Implémentez la logique pour déterminer le type de vol
            return "";
        }
        public DateTime CalculerFdp()
        {
            // Implémentez la logique pour calculer la date de fin de planification
            return DateTime.Now;
        }
        public Aeroport GetFromDestination()
        {
            // Implémentez la logique pour récupérer l'aéroport de départ
            return new Aeroport();
        }
        public Aeroport GetToDestination()
        {
            // Implémentez la logique pour récupérer l'aéroport d'arrivée
            return new Aeroport();
        }
        public DateTime GetStartTime()
        {
            // Implémentez la logique pour récupérer l'heure de départ
            return DateTime.Now;
        }
        public DateTime GetEndTime()
        {
            // Implémentez la logique pour récupérer l'heure d'arrivée
            return DateTime.Now;
        }
        public TimeSpan GetFlightDuration()
        {
            // Implémentez la logique pour calculer la durée du vol
            return TimeSpan.Zero;

        }
    }
}
