using FlyTime.Core.Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Repositories
{
    public interface IPilotRepository : IRepository<Pilot>
    {
        Task<IEnumerable<Pilot>> GetAllWithVolsAsync();
        Task<Pilot> GetWithVolsByIdAsync(int id);
    }
}
