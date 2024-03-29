﻿namespace BadgeTracker.Data
{
    /// <summary>
    /// User data service interface.
    /// </summary>
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetAllUsers();
        Task AddBadgeToUser(User user, Badge badge);
        Task AddActivityToUser(User user, Activity activity);
        Task RemoveBadgeFromUser(EarnedBadge badge);
        Task RemoveActivityFromUser(CompletedActivity activity);
        Task UpdateUser(User user);
        Task AddUser(User user);
        Task DeleteUser(User user);
    }
}
