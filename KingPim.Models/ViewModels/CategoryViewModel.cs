using System;
using System.Collections.Generic;

namespace KingPim.Models.ViewModels
{
    [Serializable]
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubcategoryViewModel> Subcategories { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Published { get; set; }
        public double Version { get; set; }
        public string ModifiedBy { get; set; }
    }
}
