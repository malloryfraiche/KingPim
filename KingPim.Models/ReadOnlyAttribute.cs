using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models
{
    public class ReadOnlyAttribute
    {
        public DateTime UpdatedDate { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Published { get; set; }
        public double Version { get; set; }

        //public virtual IdentityUser IdentityUser { get; set; }
        //public int IdentityUserId { get; set; }
    }
}
