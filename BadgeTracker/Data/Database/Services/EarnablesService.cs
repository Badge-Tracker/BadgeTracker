using Microsoft.EntityFrameworkCore;

namespace BadgeTracker.Data
{
    public class EarnablesService
    {
        public async Task<List<Badge>> GetAllBadges()
        {
            using var dbContext = DbContextFactory.CreateInstance();
            return await dbContext.Set<Badge>().ToListAsync();

        }

        public async Task<Activity> GetAllActivities()
        {
            using var dbContext = DbContextFactory.CreateInstance();
            throw new NotImplementedException();
        }

        public async Task<EarnedEarnable> GetCompletedEarnablesByUserId(int userId)
        {
            using var dbContext = DbContextFactory.CreateInstance();
            throw new NotImplementedException();
        }

        public async Task<EarnedBadge> GetCompletedBadgesByBadgeId(int badgeId)
        {
            using var dbContext = DbContextFactory.CreateInstance();
            throw new NotImplementedException();
        }

        public async Task<CompletedActivity> GetCompletedActivitiesByActivityId(int activityId)
        {
            using var dbContext = DbContextFactory.CreateInstance();
            throw new NotImplementedException();
        }
    }
}
