namespace BadgeTracker.Data
{
    public interface IEarnablesService
    {
        Task<Activity> GetAllActivities();
        Task<Badge> GetAllBadges();
        Task<EarnedEarnable> GetCompletedEarnablesByUserId(int userId);
        Task<EarnedBadge> GetCompletedBadgesByBadgeId(int badgeId);
        Task<CompletedActivity> GetCompletedActivitiesByActivityId(int activityId);
    }
}
