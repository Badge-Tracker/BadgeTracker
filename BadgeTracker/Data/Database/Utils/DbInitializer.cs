namespace BadgeTracker.Data
{
    public class DbInitializer
    {
        private static readonly Random rng = new();

        public static void Initialize(TrackerDbContext context)
        {
            context.Database.EnsureCreated();

            InitializeBadges(context);
        }

        private static void InitializeBadges(TrackerDbContext context)
        {
            List<Badge> badges = new();

            badges.Add(new Badge
            {
                Prerequisites = new Prerequisites(),
                Name = "Test badge",
                CreatedBy = 1337,
                Description = ""
            });

            context.Badges.AddRange(badges);
            context.SaveChanges();
        }
    }
}
