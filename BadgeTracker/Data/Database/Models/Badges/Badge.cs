using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    /// <summary>
    /// Badge class which extends Earnable.
    /// </summary>
    public class Badge : Earnable
    {
        /// <summary>
        /// ID of the Badge.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Prerequisites for this Badge. Empty by default.
        /// </summary>
        public Prerequisites Prerequisites { get; set; } = new Prerequisites();
    }
}
