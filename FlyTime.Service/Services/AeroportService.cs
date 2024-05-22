// using FlyTime.core.Models1;
// using FlyTime.core.Repositories1;
// using FlyTime.core.Services1;
// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace FlyTime.Service.Services
// {
//     public class AeroportService : IAeroportService
//     {
//         public readonly IAeroportRepository repo;

//         public Task<Aeroport> CreateAeroport(Aeroport aeroport)
//         {
//             return repo.AddAsync(aeroport);
//         }

//         public void DeleteAeroport(int id)
//         {
//             Aeroport aeroportToDelete = repo.GetByIdAsync(id).Result;
//             repo.Remove(aeroportToDelete);
//         }

//         public Task<IEnumerable<Aeroport>> GetAeroportByCity(string city)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<IEnumerable<Aeroport>> GetAeroportByCountry(string name)
//         {
//             throw new NotImplementedException();
//         }

//         public ValueTask<Aeroport> GetAeroportById(int id)
//         {
//             return repo.GetByIdAsync(id);
//         }

//         public Task<Aeroport> GetAeroportByName(string name)
//         {
//             return repo.GetByName(name);
//         }

//         public Task<IEnumerable<Aeroport>> GetAllAeroports()
//         {
//             return repo.GetAllAsync();
//         }

//         public Task<Aeroport> UpdateAeroport(Aeroport aeroport, int id)
//         {
//             ValueTask<Aeroport> checkAeroport = repo.GetByIdAsync(id);

//             Aeroport aeroportFromDb;

//             if (checkAeroport.IsCompletedSuccessfully)
//             {
//                 aeroportFromDb = checkAeroport.Result;

//                 aeroportFromDb.Name = aeroport.Name;
//                 aeroportFromDb.Code = aeroport.Code;
//                 aeroportFromDb.City = aeroport.City;
//                 aeroportFromDb.Country = aeroport.Country;

//                 return repo.AddAsync(aeroportFromDb);
//             }
//             else
//             {
//                 throw new Exception("Operation Canceled or Aeroport not found");
//             }

//             return null;
//         }
//     }
// }
using FlyTime.core.Models1;
using FlyTime.core.Repositories1;
using FlyTime.core.Services1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlyTime.Service.Services
{
    public class AeroportService : IAeroportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AeroportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Aeroport> CreateAeroport(Aeroport aeroport)
        {
            await _unitOfWork.AeroportRepository.AddAsync(aeroport);
            await _unitOfWork.CommitAsync();
            return aeroport;
        }

        public async Task DeleteAeroport(int id)
        {
            var aeroportToDelete = await _unitOfWork.AeroportRepository.GetByIdAsync(id);
            _unitOfWork.AeroportRepository.Remove(aeroportToDelete);
            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<Aeroport>> GetAeroportByCity(string city)
        {
            return _unitOfWork.AeroportRepository.GetByCity(city);
        }

        public Task<IEnumerable<Aeroport>> GetAeroportByCountry(string country)
        {
            return _unitOfWork.AeroportRepository.GetByCountry(country);
        }

        public Task<Aeroport> GetAeroportById(int id)
        {
            return _unitOfWork.AeroportRepository.GetByIdAsync(id);
        }

        public Task<Aeroport> GetAeroportByName(string name)
        {
            return _unitOfWork.AeroportRepository.GetByName(name);
        }

        public Task<IEnumerable<Aeroport>> GetAllAeroports()
        {
            return _unitOfWork.AeroportRepository.GetAllAsync();
        }

        public async Task<Aeroport> UpdateAeroport(Aeroport aeroport, int id)
        {
            var existingAeroport = await _unitOfWork.AeroportRepository.GetByIdAsync(id);

            if (existingAeroport == null)
            {
                throw new Exception("Aeroport not found");
            }

            // Mettre à jour les propriétés de l'aéroport existant avec les nouvelles valeurs
            existingAeroport.Name = aeroport.Name;
            existingAeroport.Code = aeroport.Code;
            existingAeroport.City = aeroport.City;
            existingAeroport.Country = aeroport.Country;

            _unitOfWork.AeroportRepository.Update(existingAeroport);
            await _unitOfWork.CommitAsync();

            return existingAeroport;
        }
    }
}
