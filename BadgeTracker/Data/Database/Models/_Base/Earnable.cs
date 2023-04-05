using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    /// <summary>
    /// Earnable class which represents any object that can be earned.
    /// Includes: Badges, Activities.
    /// </summary>
    public abstract class Earnable
    {
        /// <summary>
        /// Name of the Earnable.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the Earnable.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Who the Earnable was created by.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Date and time of creation.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Whether the Earnable is still obtainable or if it is discontinued.
        /// </summary>
        public bool IsObtainable { get; set; } = true;
    }
}
