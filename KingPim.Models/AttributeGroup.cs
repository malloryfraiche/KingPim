using System.Collections.Generic;

namespace KingPim.Models
{
    public class AttributeGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<ProductAttribute> ProductAttributes { get; set; }
    }
}
