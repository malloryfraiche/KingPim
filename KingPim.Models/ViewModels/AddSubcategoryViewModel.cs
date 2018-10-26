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
        public IEnumerable<Category> Category { get; set; }
        public int Version { get; set; }
    }
}
