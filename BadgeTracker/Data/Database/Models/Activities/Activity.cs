using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    public class Activity : Earnable
    {
        [Key]
        public int ActivityID { get; set; }
    }
}
