namespace BadgeTracker.Data
{
    public class CompletedActivity : EarnedEarnable
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
