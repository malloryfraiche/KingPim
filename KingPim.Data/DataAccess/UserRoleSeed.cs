using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Data.DataAccess
{
    public class UserRoleSeed : IUserRoleSeed
    {
        //private readonly ApplicationDbContext _context;
        //public UserRoleSeed(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<bool> CreateUserRoleIfEmpty()
        //{
        //    if (!_context.UserRoles.Any())
        //    {

                

                //        var administrator = new IdentityUserRole
                //        {
                //            UserId = 1,
                //            RoleId = 1
                //        };

                //        var editor = new IdentityUserRole
                //        {
                //            UserId = 2,
                //            RoleId = 2
                //        };

                //        var publisher = new IdentityUserRole
                //        {
                //            UserId = 3,
                //            RoleId = 3
                //        };

                //        var admin = await .CreateAsync(administrator);
                //        var edit = await .CreateAsync(editor);
                //        var publish = await .CreateAsync(publisher);

                //        var userRoleSeed1 = admin.Succeeded;
                //        var userRoleSeed2 = edit.Succeeded;
                //        var userRoleSeed3 = publish.Succeeded;
    //        }
    //        return true;
    //    }
    }
}
