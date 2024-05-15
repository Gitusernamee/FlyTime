using System;
using System.Collections.Generic;

namespace FlyTime.Core.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public Pilot Pilot { get; set; }
        public List<Activity> Activities { get; set; }
        public string DeterminerTypeVol() 
        {
            // Implémentez la logique pour déterminer le type de vol
        }
        public DateTime CalculerFdp() 
        {
            // Implémentez la logique pour calculer la date de fin de planification
        }
        public Airport GetFromDestination() 
        {
            // Implémentez la logique pour récupérer l'aéroport de départ
        }
        public Airport GetToDestination() 
        {
            // Implémentez la logique pour récupérer l'aéroport d'arrivée
        }
        public DateTime GetStartTime() 
        {
            // Implémentez la logique pour récupérer l'heure de départ
        }
        public DateTime GetEndTime() 
        {
            // Implémentez la logique pour récupérer l'heure d'arrivée
        }
        public TimeSpan GetFlightDuration() 
        {
            // Implémentez la logique pour calculer la durée du vol
        }
    }
}
