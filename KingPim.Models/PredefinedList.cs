using System.Collections.Generic;

namespace KingPim.Models
{
    public class PredefinedList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<PredefinedListOption> PredefinedListOptions { get; set; }
    }
}
