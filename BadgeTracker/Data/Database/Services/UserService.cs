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
    }
}
