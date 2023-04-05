using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    // TODO: Currently not implemented.
    /// <summary>
    /// Role class which represents a user's role.
    /// Users can have more than one role.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Key for the Role.
        /// </summary>
        [Key]
        public int RoleId { get; set; }

        /// <summary>
        /// ID of the user this role is for.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User object matching the above UserID.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Role type.
        /// </summary>
        public int RoleType { get; set; }

        /// <summary>
        /// Optional ability to set an expiry date for the role.
        /// For instance, if a user is a Guide, they are a guide
        /// until they reach a certain age. This expiry can be
        /// set based on when they will no longer be eligible
        /// for that role.
        /// </summary>
        public DateTime? RoleExpiry { get; set; } = null;

        /// <summary>
        /// Persists the role which was present before the expiry
        /// just in case this information is needed.
        /// </summary>
        public int RoleTypeBeforeExpiry { get; set; }
    }
}
