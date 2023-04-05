namespace BadgeTracker.Data
{
    /// <summary>
    /// EarnedBadge class which extends EarnedEarnable.
    /// </summary>
    public class EarnedBadge : EarnedEarnable
    {
        /// <summary>
        /// The ID of the Badge earned.
        /// </summary>
        public int BadgeId { get; set; }

        /// <summary>
        /// The Badge object that was earned.
        /// </summary>
        public Badge Badge { get; set; }

        /// <summary>
        /// The date the Badge was given and awarded to the user.
        /// </summary>
        public DateTime DateAwarded { get; set; } = DateTime.Now;

        /// <summary>
        /// The ID of the administrator user who awarded the badge to the user.
        /// </summary>
        public int AwardedBy { get; set; }
    }
}
