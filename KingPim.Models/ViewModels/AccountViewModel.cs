using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingPim.Models.ViewModels
{
    public class AccountViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        [Required]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }



        public IEnumerable<IdentityUser> Users { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
    }
}
