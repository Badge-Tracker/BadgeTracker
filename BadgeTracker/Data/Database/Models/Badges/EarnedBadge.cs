namespace BadgeTracker.Data
{
    public class EarnedBadge : EarnedEarnable
    {
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
        public DateTime DateAwarded { get; set; } = DateTime.Now;
        public int AwardedBy { get; set; }
    }
}
