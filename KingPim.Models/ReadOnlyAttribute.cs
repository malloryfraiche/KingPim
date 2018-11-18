using System;

namespace KingPim.Models
{
    public class ReadOnlyAttribute
    {
        public DateTime UpdatedDate { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Published { get; set; }
        public double Version { get; set; }
        public string ModifiedBy { get; set; }
    }
}
