using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Data.DataAccess
{
    public class RoleSeed : IRoleSeed
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleSeed(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleIfEmpty()
        {
            if (!_context.Roles.Any())
            {
                var administrator = new IdentityRole
                {
                    Name = "Administrator"
                };

                var editor = new IdentityRole
                {
                    Name = "Editor"
                };

                var publisher = new IdentityRole
                {
                    Name = "Publisher"
                };

                var admin = await _roleManager.CreateAsync(administrator);
                var edit = await _roleManager.CreateAsync(editor);
                var publish = await _roleManager.CreateAsync(publisher);

                var roleSeed1 = admin.Succeeded;
                var roleSeed2 = edit.Succeeded;
                var roleSeed3 = publish.Succeeded;
            }
            return true;
        }
    }
}
