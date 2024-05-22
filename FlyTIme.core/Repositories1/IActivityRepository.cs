using FlyTime.Core.Models1;

namespace FlyTime.Core.Repositories
{
    public interface IActivityRepository : IRepository<Activity>
    {
        public Task<Activity> GetByEndTime(DateTime endTime);
        public Task<Activity> GetByStartTime(DateTime startTime);
        Task<IEnumerable<Activity>> GetActivityByVol(Vol vol);

    }
}