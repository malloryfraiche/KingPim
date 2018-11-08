using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int SubcategoryId { get; set; }  // For 'add new product' - to save a product under a subcategory.
        public IEnumerable<Subcategory> Subcategory { get; set; }   // For 'add new product' - to get a dropdown list of the subcats for the user to choose from.

        public IEnumerable<Product> Products { get; set; }  // For the Product Index view.
    }
}
