using System.Collections.Generic;

namespace KingPim.Models.ViewModels
{
    public class AddSubcategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Category { get; set; }     // to get the categories in the 'add new subcat' dropdown list.
        public string ModifiedBy { get; set; }
        public IEnumerable<AttributeGroup> AttributeGroups { get; set; }    // to get the attributegroups in the 'add new subcat' table.((DONT USE THIS ANYMORE))
        public List<int> AttributeGroupId { get; set; }
    }
}
