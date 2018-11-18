namespace KingPim.Models
{
    public class Product : ReadOnlyAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public int? SubcategoryId { get; set; }
    }
}
