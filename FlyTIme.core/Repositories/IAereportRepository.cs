namespace FlyTime.Core.Repositories
{
    public interface IAirportRepository
    {
        Airport GetAirportById(int id);
        IEnumerable<Airport> GetAllAirports();
        void AddAirport(Airport airport);
        void UpdateAirport(Airport airport);
        void RemoveAirport(int id);
        // Autres méthodes de repository si nécessaire
    }
}
