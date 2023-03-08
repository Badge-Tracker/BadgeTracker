using Microsoft.EntityFrameworkCore;

namespace BadgeTracker.Data
{
    public class DbContextFactory
    {
        private static DbContextOptions dbContextOptions = null;

        /// <summary>
        /// Set the connection string for the DB context factory. 
        /// Created contexts will use this connection string. 
        /// </summary>
        /// <param name="connectionStringID">The connection string ID in app settings</param>
        public static void SetConnectionString(string connectionStringID)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();


            dbContextOptions = new DbContextOptionsBuilder<TrackerDbContext>()
                .UseSqlite(configuration.GetConnectionString(connectionStringID))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
        }

        /// <summary>
        /// Create a new instance of  TrackerDbContext.
        /// Returns null if no connection string has been set.
        /// </summary>
        /// <returns>New instance of TrackerDbContext.</returns>
        public static TrackerDbContext CreateInstance()
        {
            if (dbContextOptions == null) return null;

            return new TrackerDbContext(dbContextOptions);
        }
    }
}
