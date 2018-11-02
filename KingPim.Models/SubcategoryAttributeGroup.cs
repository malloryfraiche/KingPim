using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models
{
    public class SubcategoryAttributeGroup
    {
        public int Id { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public int? SubcategoryId { get; set; }
        public virtual AttributeGroup AttributeGroup { get; set; }
        public int? AttributeGroupId { get; set; }
    }
}
