namespace BadgeTracker.Data
{
    /// <summary>
    /// Prerequisites class which contains a list of prerequisite badges and activites.
    /// </summary>
    public class Prerequisites
    {
        /// <summary>
        /// List of prerequisite badges.
        /// </summary>
        public List<Badge> Badges { get; set; } = new List<Badge>();

        /// <summary>
        /// List of prerequisite activities.
        /// </summary>
        public List<Activity> Activities { get; set; } = new List<Activity>();
    }
}
