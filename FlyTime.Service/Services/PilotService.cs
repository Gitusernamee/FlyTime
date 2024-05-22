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
    public class PilotService : IPilotService
    {
        private readonly IPilotRepository repo;

        public Task<Pilot> CreatePilot(Pilot pilot)
        {
            return repo.AddAsync(pilot);
        }

        public void DeletePilot(Pilot pilot)
        {
            repo.Remove(pilot);
        }

        public Task<IEnumerable<Pilot>> GetAllPilots()
        {
            return repo.GetAllAsync();
        }

        public ValueTask<Pilot> GetPilotById(int id)
        {
            return repo.GetByIdAsync(id);
        }

        public Task<Pilot> UpdatePilote(Pilot pilot, int id)
        {
            ValueTask<Pilot> checkPilot = repo.GetByIdAsync(id);

            Pilot pilotFromDb;

            if (checkPilot.IsCompletedSuccessfully)
            {
                pilotFromDb = checkPilot.Result;

                pilotFromDb.Email = pilot.Email;
                pilotFromDb.Password = pilot.Password;
                pilotFromDb.Matricule = pilot.Matricule;

                return repo.AddAsync(pilotFromDb);
            }
            else
            {
                throw new Exception("Operation Canceled or Aeroport not found");
            }

            return null;
        }
    }
}
