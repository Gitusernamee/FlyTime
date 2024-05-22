using FlyTime.Core.Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Services
{
    public interface IPilotService
    {
        Task<IEnumerable<Pilot>> GetAllPilots();
        ValueTask<Pilot> GetPilotById(int id);
        Task<Pilot> CreatePilot(Pilot pilot);
        Task<Pilot> UpdatePilote(Pilot pilot, int id);
        void DeletePilot(Pilot pilot);
    }
}
