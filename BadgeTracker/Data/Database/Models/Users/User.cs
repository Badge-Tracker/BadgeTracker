using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public Role Role { get; set; }
    }
}
