using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.ViewModels
{
    public class AddCategoryViewModel
    {
        public string Name { get; set; }
        public List<string> Subcategories { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Published { get; set; }
        public double Version { get; set; }
    }
}
