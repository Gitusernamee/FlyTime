using FlyTime.core.Models1;
using FlyTime.core.Repositories1;
using FlyTime.core.Services1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Service.Services
{
    public class AeroportService : IAeroportService
    {
        public readonly IAeroportRepository repo;

        public Task<Aeroport> CreateAeroport(Aeroport aeroport)
        {
            return repo.AddAsync(aeroport);
        }

        public void DeleteAeroport(int id)
        {
            Aeroport aeroportToDelete = repo.GetByIdAsync(id).Result;
            repo.Remove(aeroportToDelete);
        }

        public Task<IEnumerable<Aeroport>> GetAeroportByCity(string city)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aeroport>> GetAeroportByCountry(string name)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Aeroport> GetAeroportById(int id)
        {
            return repo.GetByIdAsync(id);
        }

        public Task<Aeroport> GetAeroportByName(string name)
        {
            return repo.GetByName(name);
        }

        public Task<IEnumerable<Aeroport>> GetAllAeroports()
        {
            return repo.GetAllAsync();
        }

        public Task<Aeroport> UpdateAeroport(Aeroport aeroport, int id)
        {
            ValueTask<Aeroport> checkAeroport = repo.GetByIdAsync(id);

            Aeroport aeroportFromDb;

            if (checkAeroport.IsCompletedSuccessfully)
            {
                aeroportFromDb = checkAeroport.Result;

                aeroportFromDb.Name = aeroport.Name;
                aeroportFromDb.Code = aeroport.Code;
                aeroportFromDb.City = aeroport.City;
                aeroportFromDb.Country = aeroport.Country;

                return repo.AddAsync(aeroportFromDb);
            }
            else
            {
                throw new Exception("Operation Canceled or Aeroport not found");
            }

            return null;
        }
    }
}
