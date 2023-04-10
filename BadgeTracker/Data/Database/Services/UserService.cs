using Microsoft.EntityFrameworkCore;

namespace BadgeTracker.Data
{
    /// <summary>
    /// User data service.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Fetch user by ID.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>Specified user.</returns>
        public async Task<User> GetUserById(int id)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            }
        }

        /// <summary>
        /// Fetch user by name.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <returns>Specified user.</returns>
        public async Task<User> GetUserByName(string name)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.Users.Where(u => u.Name == name).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            }
        }

        /// <summary>
        /// Fetch user by email.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <returns>Specified user.</returns>
        public async Task<User> GetUserByEmail(string email)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            }
        }

        /// <summary>
        /// Fetch all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        public async Task<List<User>> GetAllUsers()
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                return await dbContext.Users.ToListAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
                return null;
            }
        }

        /// <summary>
        /// Add an earned badge to user.
        /// </summary>
        /// <param name="user">User to add to.</param>
        /// <param name="badge">Badge to add.</param>
        /// <returns>Task.</returns>
        public async Task AddBadgeToUser(User user, Badge badge)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            EarnedBadge earnedBadge = new()
            {
                UserId = user.UserId,
                BadgeId = badge.Id,
                AwardedBy = 0, // TODO: Not implemented.
                CompletedBy = 0 // TODO: Not implemented.
            };

            try
            {
                dbContext.EarnedBadges.Add(earnedBadge);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
            }
        }

        /// <summary>
        /// Add a completed activity to a user.
        /// </summary>
        /// <param name="user">User to add to.</param>
        /// <param name="activity">Activity to add.</param>
        /// <returns>Task.</returns>
        public async Task AddActivityToUser(User user, Activity activity)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            CompletedActivity completedActivity = new()
            {
                ActivityId = activity.Id,
                UserId = user.UserId,
                CompletedBy = 0 // TODO: Not implemented.
            };

            try
            {
                dbContext.CompletedActivities.Add(completedActivity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
            }
        }

        /// <summary>
        /// Update a user in the database.
        /// </summary>
        /// <param name="user">Updated user.</param>
        /// <returns></returns>
        public async Task UpdateUser(User user)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                dbContext.Update(user);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
            }
        }

        /// <summary>
        /// Add a new user to the database.
        /// </summary>
        /// <param name="user">New user to add.</param>
        /// <returns>Task.</returns>
        public async Task AddUser(User user)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
            }
        }

        /// <summary>
        /// Remove earned badge from user.
        /// </summary>
        /// <param name="badge">Badge to remove.</param>
        /// <returns>Task.</returns>
        public async Task RemoveBadgeFromUser(EarnedBadge badge)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                dbContext.EarnedBadges.Remove(badge);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
            }
        }

        /// <summary>
        /// Remove completed activity from user.
        /// </summary>
        /// <param name="activity">Activity to remove.</param>
        /// <returns></returns>
        public async Task RemoveActivityFromUser(CompletedActivity activity)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                dbContext.CompletedActivities.Remove(activity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
            }
        }

        /// <summary>
        /// Delete user from database.
        /// </summary>
        /// <param name="user">User to delete.</param>
        /// <returns></returns>
        public async Task DeleteUser(User user)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            try
            {
                // Delete all completed activities and earned badges.
                foreach (CompletedActivity completedActivity in dbContext.CompletedActivities.Where(ca => ca.UserId == user.UserId))
                    dbContext.CompletedActivities.Remove(completedActivity);

                foreach (EarnedBadge earnedBadge in dbContext.EarnedBadges.Where(ea => ea.UserId == user.UserId))
                    dbContext.EarnedBadges.Remove(earnedBadge);

                // Delete user.
                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // Logs errors later.
            }
        }
    }
}
