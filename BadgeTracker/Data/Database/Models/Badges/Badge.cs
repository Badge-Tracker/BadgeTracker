using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    public class Badge : Earnable
    {
        [Key]
        public int Id { get; set; }
        public Prerequisites Prerequisites { get; set; }
    }
}
