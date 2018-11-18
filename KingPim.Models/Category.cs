using System.Collections.Generic;

namespace KingPim.Models
{
    public class Category : ReadOnlyAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Subcategory> Subcategories { get; set; }
    }
}
