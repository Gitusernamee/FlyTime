using FlyTime.core.Models1;
using FlyTime.core.Repositories1;
using FlyTime.core.Services1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyTime.Service.Services
{
    public class VolService : IVolService
    {
        private readonly IVolRepository repo;

        public Task<Vol> CreateVol(Vol vol)
        {
            return repo.AddAsync(vol);
        }

        public void DeleteVol(Vol vol)
        {
            repo.Remove(vol);
        }

        public Task<IEnumerable<Vol>> GetAllVols()
        {
            return repo.GetAllAsync();
        }

        public ValueTask<Vol> GetVolById(int id)
        {
            return repo.GetByIdAsync(id);
        }

        public Task<Vol> UpdateVol(Vol vol, int id)
        {
            ValueTask<Vol> checkVol = repo.GetByIdAsync(id);

            Vol volFromDb;

            if (checkVol.IsCompletedSuccessfully)
            {
                volFromDb = checkVol.Result;

                volFromDb.Pilot = vol.Pilot;
                volFromDb.Activities = vol.Activities;

                return repo.AddAsync(volFromDb);
            }
            else
            {
                throw new Exception("Operation Canceled or Flight not found");
            }

            return null;
        }
    }
}
