using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            // Have the whole King Pim site access here...
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Users(AccountViewModel vm)
        {
            ViewBag.Title = "Users";

            var userRoleInfo = new AccountViewModel
            {
                Users = _userManager.Users,
                Roles = _roleManager.Roles
            };

            return View(userRoleInfo);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AccountViewModel vm)
        {

            var user = new IdentityUser
            {
                UserName = vm.UserName,
                Email = vm.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded)
            {
                var findByEmail = await _userManager.FindByEmailAsync(user.Email);
                await _userManager.AddToRoleAsync(findByEmail, vm.Role);
            }

            return RedirectToAction(nameof(Users));
        }

        [HttpPost]
        public IActionResult ChangePassword(AccountViewModel vm)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}