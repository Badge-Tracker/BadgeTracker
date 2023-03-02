using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BadgeTracker.Data
{
    public class TrackerDbContext : DbContext
    {
        public TrackerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<CompletedActivity> CompletedActivities { get; set; }

        public DbSet<Badge> Badges { get; set; }
        public DbSet<EarnedBadge> EarnedBadges { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().ToTable("Activities");

            modelBuilder.Entity<CompletedActivity>().ToTable("CompletedActivities");
            modelBuilder.Entity<CompletedActivity>()
                .HasKey(ca => new {ca.ActivityId, ca.UserId});
            modelBuilder.Entity<CompletedActivity>().ToTable("CompletedActivities");
            modelBuilder.Entity<CompletedActivity>()
                .HasOne(ca => ca.Activity)
                .WithMany()
                .HasForeignKey(a => a.ActivityId)
                .OnDelete(DeleteBehavior.Cascade); // Deletes the CompletedActivity record if the Activity is deleted.


            modelBuilder.Entity<Badge>().ToTable("Badges");
            modelBuilder.Entity<Badge>()
                .Property(b => b.Prerequisites)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    }),
                    v => JsonConvert.DeserializeObject<Prerequisites>(v, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    })
                );

            modelBuilder.Entity<EarnedBadge>().ToTable("EarnedBadges");
            modelBuilder.Entity<EarnedBadge>()
                .HasKey(eb => new { eb.BadgeId, eb.UserId });
            modelBuilder.Entity<EarnedBadge>()
                .HasOne(eb => eb.Badge)
                .WithMany()
                .HasForeignKey(b => b.BadgeId)
                .OnDelete(DeleteBehavior.Cascade); // Deletes the EarnedBadge record if the Badge is deleted.


            modelBuilder.Entity<User>().ToTable("Users")
                .HasOne(u => u.Role)
                .WithOne(r => r.User)
                .HasForeignKey<Role>(r => r.UserId);

            modelBuilder.Entity<Role>().ToTable("Roles");
        }
    }
}
