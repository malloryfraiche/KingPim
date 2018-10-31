using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.ViewModels
{
    public class ProductAttributeValueViewModel
    {
        public int Id { get; set; }     // ProductAttributeValue usage.
        public string Value { get; set; }       // ProductAttributeValue usage.
        public int ProductAttributeId { get; set; }     // ProductAttributeValue usage.
        public int ProductId { get; set; }      // ProductAttributeValue usage.
        public IEnumerable<Subcategory> Subcategory { get; set; }     // To have access to the AttributeGroup and ProductAttribute data.
    }
}
