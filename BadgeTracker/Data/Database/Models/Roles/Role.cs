using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleType { get; set; }
        public DateTime? RoleExpiry { get; set; } = null;
        public int RoleTypeBeforeExpiry { get; set; }
    }
}
