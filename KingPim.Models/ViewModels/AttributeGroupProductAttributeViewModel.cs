using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.ViewModels
{
    public class AttributeGroupProductAttributeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }            
        public int AttributeGroupId { get; set; }   
        public IEnumerable<AttributeGroup> AttributeGroup { get; set; }     

        public string PredefinedListName { get; set; }
        public int PredefinedListId { get; set; }
        public List<string> PredefinedListOptionNames { get; set; }
    }
}
