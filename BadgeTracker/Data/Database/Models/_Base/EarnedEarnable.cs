using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    /// <summary>
    /// EarnedEarnable class representing an Earnable that has been earned
    /// or completed by a user.
    /// </summary>
    public abstract class EarnedEarnable
    {
        /// <summary>
        /// ID of the user who earned or completed the Earnable.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Date the Earnable was earned or completed.
        /// </summary>
        public DateTime DateCompleted { get; set; } = DateTime.Now;

        /// <summary>
        /// ID of the administrator user who marked this Earnable as earned
        /// or completed.
        /// </summary>
        public int CompletedBy { get; set; }
    }
}
