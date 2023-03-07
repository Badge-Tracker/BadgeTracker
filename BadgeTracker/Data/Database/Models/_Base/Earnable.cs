using System.ComponentModel.DataAnnotations;

namespace BadgeTracker.Data
{
    public abstract class Earnable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsObtainable { get; set; } = true;
    }
}
