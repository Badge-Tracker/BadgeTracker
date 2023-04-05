namespace BadgeTracker.Data
{
    /// <summary>
    /// CompletedActivity class which extends EarnedEarnable.
    /// </summary>
    public class CompletedActivity : EarnedEarnable
    {
        /// <summary>
        /// ID of the activity completed.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Reference to the Activity object that has been completed.
        /// </summary>
        public Activity Activity { get; set; }
    }
}
