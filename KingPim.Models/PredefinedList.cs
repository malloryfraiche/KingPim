using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models
{
    public class PredefinedList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<PredefinedListOption> PredefinedListOptions { get; set; }
    }
}
