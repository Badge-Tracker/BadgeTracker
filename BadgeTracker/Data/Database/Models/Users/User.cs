using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data.Database.Models.Users
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
