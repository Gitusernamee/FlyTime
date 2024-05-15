namespace FlyTime.Core.Repositories
{
    public interface IActivityRepository
    {
        Activity GetActivityById(int id);
        IEnumerable<Activity> GetAllActivities();
        void AddActivity(Activity activity);
        void UpdateActivity(Activity activity);
        void RemoveActivity(int id);

    }
}
