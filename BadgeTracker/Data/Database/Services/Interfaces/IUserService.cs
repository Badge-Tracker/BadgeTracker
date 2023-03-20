namespace BadgeTracker.Data
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetAllUsers();
        Task AddBadgeToUser(User user, Badge badge);
        Task AddActivityToUser(User user, Activity activity);
        Task UpdateUser(User user);
        Task AddUser(User user);
    }
}
