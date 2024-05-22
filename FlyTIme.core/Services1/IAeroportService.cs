using FlyTime.Core.Models1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Core.Services
{
    public interface IAeroportService
    {
        Task<IEnumerable<Aeroport>> GetAllAeroports();
        ValueTask<Aeroport> GetAeroportById(int id);
        Task<IEnumerable<Aeroport>> GetAeroportByCity(string city);
        Task<IEnumerable<Aeroport>> GetAeroportByCountry(string name);
        Task<Aeroport> GetAeroportByName(string name);
        Task<Aeroport> CreateAeroport(Aeroport aeroport);
        Task<Aeroport> UpdateAeroport(Aeroport aeroport, int id);
        void DeleteAeroport(int id);
    }
}
