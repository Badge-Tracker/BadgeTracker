using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    /// <summary>
    /// Activity class that extends Earnable.
    /// </summary>
    public class Activity : Earnable
    {
        /// <summary>
        /// ID of the Activity.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
