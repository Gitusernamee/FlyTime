using FlyTime.Core.Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Repositories
{
    public interface IAeroportRepository : IRepository<Aeroport>
    {
        Task<Aeroport> GetByCode(int id);
        Task<IEnumerable<Aeroport>> GetAllByCity(string city);
        Task<IEnumerable<Aeroport>> GetAllByCountry(string country);
        Task<Aeroport> GetByName(string name);
        
    }
}
