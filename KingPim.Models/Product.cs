using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Models
{
    public class Product : ReadOnlyAttribute
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public int? SubcategoryId { get; set; }

        // list of AttributeGroups
    }
}
