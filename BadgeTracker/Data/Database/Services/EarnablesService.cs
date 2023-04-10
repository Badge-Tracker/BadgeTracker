using Microsoft.EntityFrameworkCore;

namespace BadgeTracker.Data
{
    /// <summary>
    /// Earanbles data service.
    /// </summary>
    public class EarnablesService : IEarnablesService
    {
        /// <summary>
        /// Fetch all badges from the database.
        /// </summary>
        /// <returns>A list of all badges.</returns>
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

        /// <summary>
        /// Fetch all activities from the database.
        /// </summary>
        /// <returns>A list of all activities.</returns>
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

        /// <summary>
        /// Fetch a specific badge by its ID from the database.
        /// </summary>
        /// <param name="badgeId">Badge ID.</param>
        /// <returns>Specified badge.</returns>
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

        /// <summary>
        /// Fetch specific activity by its ID from the database.
        /// </summary>
        /// <param name="activityId">Activity ID.</param>
        /// <returns>Specified activity.</returns>
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

        /// <summary>
        /// Get all earned badges by user ID.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns>All of the user's earned badges.</returns>
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

        /// <summary>
        /// Get all completed activities by user ID.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <returns>All of the user's completed activities.</returns>
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

        /// <summary>
        /// Get all earned badges by badge ID.
        /// </summary>
        /// <param name="badgeId">Badge ID.</param>
        /// <returns>All earned badges of that badge ID.</returns>
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

        /// <summary>
        /// Get all completed activities by activity ID.
        /// </summary>
        /// <param name="activityId">Activity ID.</param>
        /// <returns>All completed activites of that activity ID.</returns>
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

        /// <summary>
        /// Create a new badge in the database.
        /// </summary>
        /// <param name="badge">Badge to create.</param>
        /// <returns>Task.</returns>
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

        /// <summary>
        /// Create a new activity in the database.
        /// </summary>
        /// <param name="activity">Activity to create.</param>
        /// <returns>Task.</returns>
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

        /// <summary>
        /// Delete badge from the database.
        /// </summary>
        /// <param name="badge">Badge to delete from the database.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete activity from the database.
        /// </summary>
        /// <param name="activity">Activity to delete.</param>
        /// <returns>Task.</returns>
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

        /// <summary>
        /// Update badge in the database.
        /// </summary>
        /// <param name="badge">Updated badge.</param>
        /// <returns>Task.</returns>
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

        /// <summary>
        /// Update activity in the database.
        /// </summary>
        /// <param name="activity">Updated activity.</param>
        /// <returns>Task.</returns>
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
