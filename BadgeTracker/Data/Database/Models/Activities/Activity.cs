using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    public class Activity : Earnable
    {
        [Key]
        public int Id { get; set; }
    }
}
