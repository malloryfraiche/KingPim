using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Models
{
    public class ReadOnlyAttribute
    {
        [Column(Order = 7)]
        public DateTime UpdatedDate { get; set; }
        [Column(Order = 8)]
        public DateTime AddedDate { get; set; }
        [Column(Order = 9)]
        public bool Published { get; set; }
        [Column(Order = 10)]
        public double Version { get; set; }

        // TODO: IDENTITY
        //public virtual IdentityUser IdentityUser { get; set; }
        //public int IdentityUserId { get; set; }
    }
}
