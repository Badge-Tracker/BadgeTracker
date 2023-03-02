namespace BadgeTracker.Data
{
    // TODO: Composite key : [PrimaryKey(nameof(EarnableID), nameof(UserID))]
    public abstract class EarnedEarnable
    {
        public int UserId { get; set; }
        public DateTime DateCompleted { get; set; } = DateTime.Now;
        public int CompletedBy { get; set; }
    }
}
