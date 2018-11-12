using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.ViewModels
{
    public class ProductAttributeValueViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }       
        public int? ProductAttributeId { get; set; }     
        public int? ProductId { get; set; }     
        public IEnumerable<SubcategoryAttributeGroup> CardSubcategoryAttributeGroups { get; set; }
        public IEnumerable<ProductAttributeValue> CardProductAttributeValues { get; set; }

        public ProductAttributeValueViewModel()
        {
            CardProductAttributeValues = new List<ProductAttributeValue>();
        }
    }
}
