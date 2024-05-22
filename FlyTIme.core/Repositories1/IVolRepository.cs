using FlyTime.Core.Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Repositories
{
    public interface IVolRepository : IRepository<Vol>
    {
        Task<IEnumerable<Vol>> GetAllWithActivities();
        Task<Vol> GetWithActivitiesById(int id);

    }
}
