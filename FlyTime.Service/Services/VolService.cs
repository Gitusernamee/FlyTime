// using FlyTime.core.Models1;
// using FlyTime.core.Repositories1;
// using FlyTime.core.Services1;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace FlyTime.Service.Services
// {
//     public class VolService : IVolService
//     {
//         private readonly IVolRepository repo;

//         public Task<Vol> CreateVol(Vol vol)
//         {
//             return repo.AddAsync(vol);
//         }

//         public void DeleteVol(Vol vol)
//         {
//             repo.Remove(vol);
//         }

//         public Task<IEnumerable<Vol>> GetAllVols()
//         {
//             return repo.GetAllAsync();
//         }

//         public ValueTask<Vol> GetVolById(int id)
//         {
//             return repo.GetByIdAsync(id);
//         }

//         public Task<Vol> UpdateVol(Vol vol, int id)
//         {
//             ValueTask<Vol> checkVol = repo.GetByIdAsync(id);

//             Vol volFromDb;

//             if (checkVol.IsCompletedSuccessfully)
//             {
//                 volFromDb = checkVol.Result;

//                 volFromDb.Pilot = vol.Pilot;
//                 volFromDb.Activities = vol.Activities;

//                 return repo.AddAsync(volFromDb);
//             }
//             else
//             {
//                 throw new Exception("Operation Canceled or Flight not found");
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
    public class VolService : IVolService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Vol> CreateVol(Vol vol)
        {
            await _unitOfWork.VolRepository.AddAsync(vol);
            await _unitOfWork.CommitAsync();
            return vol;
        }

        public async Task DeleteVol(int id)
        {
            var volToDelete = await _unitOfWork.VolRepository.GetByIdAsync(id);
            _unitOfWork.VolRepository.Remove(volToDelete);
            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<Vol>> GetAllVols()
        {
            return _unitOfWork.VolRepository.GetAllAsync();
        }

        public Task<Vol> GetVolById(int id)
        {
            return _unitOfWork.VolRepository.GetByIdAsync(id);
        }

        public async Task<Vol> UpdateVol(Vol vol, int id)
        {
            var existingVol = await _unitOfWork.VolRepository.GetByIdAsync(id);

            if (existingVol == null)
            {
                throw new Exception("Vol not found");
            }

            // Mettre à jour les propriétés du vol existant avec les nouvelles valeurs
            existingVol.Pilot = vol.Pilot;
            existingVol.Activities = vol.Activities;

            _unitOfWork.VolRepository.Update(existingVol);
            await _unitOfWork.CommitAsync();

            return existingVol;
        }
    }
}
