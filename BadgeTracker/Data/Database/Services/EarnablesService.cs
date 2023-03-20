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

        public async Task<Badge> GetBadgeById(int badgeId)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.Badges.Where(b => b.Id == badgeId).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            }
        }

        public async Task<Activity> GetActivityById(int activityId)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.Activities.Where(a => a.Id == activityId).FirstOrDefaultAsync();
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
                List<EarnedBadge> badges = await dbContext.EarnedBadges.Where(eb => eb.UserId == userId).ToListAsync();
                
                // TODO: EFCore should really be handling this. Fix later.
                foreach(EarnedBadge badge in badges)
                {
                   badges.FirstOrDefault(b => b.BadgeId == badge.BadgeId).Badge = await GetBadgeById(badge.BadgeId);
                }

                return badges;
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
                 List<CompletedActivity> activities = await dbContext.CompletedActivities.Where(ca => ca.UserId == userId).ToListAsync();

                // TODO: EFCore should really be handling this. Fix later.
                foreach (CompletedActivity activity in activities)
                {
                    activities.FirstOrDefault(a => a.ActivityId == activity.ActivityId).Activity = await GetActivityById(activity.ActivityId);
                }

                return activities;
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

        public async Task CreateNewBadge(Badge badge)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
               dbContext.Badges.Add(badge);
               await dbContext.SaveChangesAsync();
            }
            catch
            {
                // Logs errors later.
            }
        }
        public async Task CreateNewActivity(Activity activity)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                dbContext.Activities.Add(activity);
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                // Logs errors later.
            }
        }

        public async Task DeleteBadge(Badge badge)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                dbContext.Badges.Remove(badge);
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                // Logs errors later.
            }
        }
        public async Task DeleteActivity(Activity activity)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                dbContext.Activities.Remove(activity);
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                // Logs errors later.
            }
        }

        public async Task UpdateBadge(Badge badge)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                dbContext.Update(badge);
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                // Logs errors later.
            }
        }

        public async Task UpdateActivity(Activity activity)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                dbContext.Update(activity);
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                // Logs errors later.
            }
        }
    }
}
