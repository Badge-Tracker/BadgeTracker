using Microsoft.EntityFrameworkCore;

namespace BadgeTracker.Data
{
    public class EarnablesService : IEarnablesService
    {
        public async Task<List<Badge>> GetAllBadges()
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.Badges.ToListAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            }

        }

        public async Task<List<Activity>> GetAllActivities()
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.Activities.ToListAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            }
        }

        public async Task<List<EarnedBadge>> GetEarnedBadgesByUserId(int userId)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.EarnedBadges.Where(eb => eb.UserId == userId).ToListAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            }
        }

        public async Task<List<CompletedActivity>> GetCompletedActivitiesByUserId(int userId)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.CompletedActivities.Where(ca => ca.UserId == userId).ToListAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            }
        }

        public async Task<List<EarnedBadge>> GetEarnedBadgesByBadgeId(int badgeId)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.EarnedBadges.Where(eb => eb.BadgeId == badgeId).ToListAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            }
        }

        public async Task<List<CompletedActivity>> GetCompletedActivitiesByActivityId(int activityId)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.CompletedActivities.Where(ca => ca.ActivityId == activityId).ToListAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            };
        }
    }
}
