using System;
using System.Collections.Generic;

namespace KingPim.Models.ViewModels
{
    [Serializable]
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Published { get; set; }
        public double Version { get; set; }
        public string ModifiedBy { get; set; }
        public int SubcategoryId { get; set; }  // For 'add new product' - to save a product under a subcategory.
        public IEnumerable<Subcategory> Subcategory { get; set; }   // For 'add new product' - to get a dropdown list of the subcats for the user to choose from.
        public IEnumerable<Product> Products { get; set; }  // For the Product Index view.
    }
}