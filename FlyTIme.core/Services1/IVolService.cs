using FlyTime.core.Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Services
{
    public interface IVolService
    {
        Task<IEnumerable<Pilot>> GetAllPilots();
        ValueTask<Pilot> GetPilotById(int id);
        Task<Pilot> CreatePilot(Pilot pilot);
        Task<Pilot> UpdatePilote(Pilot pilot);
        void DeletePilot(int id);
    }
}
