namespace BadgeTracker.Data.Database.Services
{
    public class UserService
    {
        public async Task<User> GetUserById(int id)
        {
            using var dbContext = DbContextFactory.CreateInstance();
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByName(string name)
        {
            using var dbContext = DbContextFactory.CreateInstance();
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            using var dbContext = DbContextFactory.CreateInstance();
            throw new NotImplementedException();
        }
    }
}
