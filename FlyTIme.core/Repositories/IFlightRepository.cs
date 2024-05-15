namespace FlyTime.Core.Repositories
{
    public interface IFlightRepository
    {
        Flight GetFlightById(int id);
        IEnumerable<Flight> GetAllFlights();
        void AddFlight(Flight flight);
        void UpdateFlight(Flight flight);
        void RemoveFlight(int id);
    }
}
