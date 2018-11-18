namespace KingPim.Models
{
    public class PredefinedListOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual PredefinedList PredefinedList { get; set; }
        public int? PredefinedListId { get; set; }
    }
}
