namespace BadgeTracker.Data
{
    public interface IEarnablesService
    {
        Task<List<Badge>> GetAllBadges();
        Task<List<Activity>> GetAllActivities();
        Task<List<EarnedBadge>> GetEarnedBadgesByUserId(int userId);
        Task<List<CompletedActivity>> GetCompletedActivitiesByUserId(int userId);
        Task<List<EarnedBadge>> GetEarnedBadgesByBadgeId(int badgeId);
        Task<List<CompletedActivity>> GetCompletedActivitiesByActivityId(int activityId);
    }
}
