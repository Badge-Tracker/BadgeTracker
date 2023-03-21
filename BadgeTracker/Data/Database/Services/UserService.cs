using Microsoft.EntityFrameworkCore;

namespace BadgeTracker.Data
{
    public class UserService : IUserService
    {
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
        public async Task AddBadgeToUser(User user, Badge badge)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            EarnedBadge earnedBadge = new()
            {
                UserId = user.UserId,
                BadgeId = badge.Id,
                AwardedBy = 0,
                CompletedBy = 0,
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
        public async Task AddActivityToUser(User user, Activity activity)
        {
            using var dbContext = DbContextFactory.CreateInstance();

            CompletedActivity completedActivity = new()
            {
                ActivityId = activity.Id,
                UserId = user.UserId,
                CompletedBy = 0
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
    }
}
