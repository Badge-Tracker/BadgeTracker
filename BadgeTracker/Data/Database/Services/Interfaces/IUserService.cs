namespace BadgeTracker.Data
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task<User> GetUserByEmail(string email);
    }
}
