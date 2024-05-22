using FlyTime.core.Models1;
using FlyTime.core.Repositories1;
using FlyTime.core.Services1;

namespace FlyTime.Service.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;

        public Task<Activity> CreateActivity(Activity activity)
        {
            return activityRepository.AddAsync(activity);
        }

        public void DeleteActivity(Activity activity)
        {
            activityRepository.Remove(activity);
        }

        public Task<Activity> GetActivityByEndTime(DateTime endTime)
        {
            return activityRepository.GetByEndTime(endTime);
        }

        public ValueTask<Activity> GetActivityById(int id)
        {
            return activityRepository.GetByIdAsync(id);
        }

        public Task<Activity> GetActivityByStartTime(DateTime startTime)
        {
            return activityRepository.GetByStartTime(startTime);
        }

        //***********************TODO********************************
        public Task<IEnumerable<Activity>> GetActivityByVol(Vol vol)
        {
            throw new NotImplementedException();
        }
        //***********************************************************

        public Task<Activity> UpdateActivity(Activity activity, int id)
        {
            ValueTask<Activity> checkActivity = activityRepository.GetByIdAsync(id);

            Activity activityFromDb;

            if (checkActivity.IsCompletedSuccessfully)
            {
                activityFromDb = checkActivity.Result;

                activityFromDb.FromDestination = activity.FromDestination;
                activityFromDb.ToDestination = activity.ToDestination;
                activityFromDb.StartTime = activity.StartTime;
                activityFromDb.EndTime = activity.EndTime;

                return activityRepository.AddAsync(activityFromDb);
            }
            else
            {
                throw new Exception("Operation Canceled or Activity not found");
            }

            return null;
        }
    }
}
