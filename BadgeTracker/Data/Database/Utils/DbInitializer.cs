namespace BadgeTracker.Data
{
    /// <summary>
    /// DbInitializer class used to populate the database with test information for debugging purposes.
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Initialize the database.
        /// </summary>
        public static void Initialize()
        {
            InitializeBadges();
            InitializeActivities();
            InitializeUsers();
        }

        /// <summary>
        /// Initialize test badges.
        /// </summary>
        private static void InitializeBadges()
        {
            using var context = DbContextFactory.CreateInstance();

            List<Badge> badges = new();

            for (int i = 0; i < 10; i++)
            {
                badges.Add(new Badge
                {
                    Prerequisites = new Prerequisites(),
                    Name = "Test badge " + i,
                    CreatedBy = 1,
                    Description = "A test badge!"
                });
            }

            context.Badges.AddRange(badges);
            context.SaveChanges();
        }

        /// <summary>
        /// Initialize test activities.
        /// </summary>
        private static void InitializeActivities()
        {
            using var context = DbContextFactory.CreateInstance();

            List<Activity> activities = new();

            for (int i = 0; i < 10; i++)
            {
                activities.Add(new Activity
                {
                    Name = "Test activity " + i,
                    CreatedBy = 1,
                    Description = "A test activity!"
                });
            }

            context.Activities.AddRange(activities);
            context.SaveChanges();
        }

        /// <summary>
        /// Initialize test users.
        /// </summary>
        private static void InitializeUsers()
        {
            using var context = DbContextFactory.CreateInstance();

            List<User> users = new();
            List<Role> roles = new();

            for (int i = 0; i < 10; i++)
            {
                users.Add(new User
                {
                    Name = "Test User " + i,
                    Email = "test@email",
                });
                roles.Add(new Role
                {
                    UserId = users[i].UserId,
                    User = users[i],
                    RoleType = 1
                });
            }

            context.Users.AddRange(users);
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    }
}
