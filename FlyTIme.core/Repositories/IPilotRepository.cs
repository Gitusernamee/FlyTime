using System.Collections.Generic;
using FlyTime.Core.Models;

namespace FlyTime.Core.Repositories
{
    public interface IPilotRepository
    {
        Pilot GetPilotById(int id);
        IEnumerable<Pilot> GetAllPilots();
        void AddPilot(Pilot pilot);
        void UpdatePilot(Pilot pilot);
        void RemovePilot(int id);

    }
}
