using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.ViewModels
{
    public class AddSubcategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Category> Category { get; set; }     // to get the categories in the 'add new subcat' dropdown list.


        public IEnumerable<AttributeGroup> AttributeGroups { get; set; }    // to get the attributegroups in the 'add new subcat' table.
        public List<int> AttributeGroupId { get; set; }

        //public IEnumerable<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }      // to save for the 
    }
}
