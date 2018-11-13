using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Data.DataAccess
{
    public class IdentitySeed : IIdentitySeed
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public IdentitySeed(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private const string _administrator = "administrator@kingpim.se";
        private const string _password = "password";

        private const string _editor = "editor@kingpim.se";
        private const string _password2 = "password2";

        private const string _publisher = "publisher@kingpim.se";
        private const string _password3 = "password3";

        public async Task<bool> CreateAdminAccountIfEmpty()
        {
            if (!_context.Users.Any())
            {
                var administrator = new IdentityUser
                {
                    UserName = _administrator,
                    Email = _administrator,
                    EmailConfirmed = true
                };

                var editor = new IdentityUser
                {
                    UserName = _editor,
                    Email = _editor,
                    EmailConfirmed = true
                };

                var publisher = new IdentityUser
                {
                    UserName = _publisher,
                    Email = _publisher,
                    EmailConfirmed = true
                };

                var admin = await _userManager.CreateAsync(administrator, _password);
                var edit = await _userManager.CreateAsync(editor, _password2);
                var publish = await _userManager.CreateAsync(publisher, _password3);

                var identitySeed1 = admin.Succeeded;
                var identitySeed2 = edit.Succeeded;
                var identitySeed3 = publish.Succeeded;
            }
            return true;
        }
    }
}
