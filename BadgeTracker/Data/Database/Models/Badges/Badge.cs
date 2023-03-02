using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    public class Badge : Earnable
    {
        [Key]
        public int BadgeID { get; set; }
        public string Prerequisites { get; set; }
    }
}
