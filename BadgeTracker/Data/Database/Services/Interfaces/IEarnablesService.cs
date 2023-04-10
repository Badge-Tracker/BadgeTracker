namespace BadgeTracker.Data
{
    /// <summary>
    /// Earnables data service interface.
    /// </summary>
    public interface IEarnablesService
    {
        Task<List<Badge>> GetAllBadges();
        Task<List<Activity>> GetAllActivities();
        Task<Badge> GetBadgeById(int badgeId);
        Task<Activity> GetActivityById(int activityId);
        Task<List<EarnedBadge>> GetEarnedBadgesByUserId(int userId);
        Task<List<CompletedActivity>> GetCompletedActivitiesByUserId(int userId);
        Task<List<EarnedBadge>> GetEarnedBadgesByBadgeId(int badgeId);
        Task<List<CompletedActivity>> GetCompletedActivitiesByActivityId(int activityId);
        Task CreateNewBadge(Badge badge);
        Task CreateNewActivity(Activity activity);
        Task DeleteBadge(Badge badge);
        Task DeleteActivity(Activity activity);
        Task UpdateBadge(Badge badge);
        Task UpdateActivity(Activity activity);
    }
}
