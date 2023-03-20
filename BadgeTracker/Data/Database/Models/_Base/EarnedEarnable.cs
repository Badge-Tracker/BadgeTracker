using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    public abstract class EarnedEarnable
    {
        public int UserId { get; set; }
        public DateTime DateCompleted { get; set; } = DateTime.Now;
        public int CompletedBy { get; set; }
    }
}
