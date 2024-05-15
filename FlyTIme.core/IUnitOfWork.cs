using System;
using System.Threading.Tasks;

namespace FlyTime.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPilotRepository Pilots { get; }
        IFlightRepository Flights { get; }
        IActivityRepository Activities { get; }
        IAirportRepository Airports { get; }

        Task<int> CommitAsync();
    }
}
