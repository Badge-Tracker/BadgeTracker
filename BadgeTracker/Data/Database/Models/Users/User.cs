using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    /// <summary>
    /// User class which represents a user of the applicaiton.
    /// </summary>
    public class User
    {
        /// <summary>
        /// User's ID.
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// User's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User's email.
        /// </summary>
        public string? Email { get; set; }

        // TODO: Not implemented.
        /// <summary>
        /// User's role.
        /// </summary>
        public Role Role { get; set; }
    }
}
