using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Models
{
    public class Subcategory : ReadOnlyAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public int? CategoryId { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
    }
}
