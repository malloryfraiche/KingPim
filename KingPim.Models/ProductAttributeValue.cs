namespace KingPim.Models
{
    public class ProductAttributeValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
        public int? ProductAttributeId { get; set; }
        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }   
    }
}
