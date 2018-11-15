using System.Threading.Tasks;
using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            // If the user is authenticated, get directed to /Account.
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                var successResetMsg = TempData["PasswordResetSuccess"];
                ViewBag.SuccessResetMsg = successResetMsg;
                var checkYourEmail = TempData["CheckYourEmail"];
                ViewBag.CheckYourEmail = checkYourEmail;
                return View();
            }
        }
        
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            // Checks if the username and password is correct.
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(vm.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, vm.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }
                }
            }
            // If not correct, we are returned to the 'login page'.
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(LoginViewModel vm)
        {
            var user = await _userManager.FindByNameAsync(vm.UserName);
            var confirmationCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action(
                controller: "Home",
                action: "ResetPassword",
                values: new { userId = user.Id, code = confirmationCode },
                protocol: Request.Scheme);
            var client = new SendGridClient("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");
            // Initiate a new send grid message.
            var msg = new SendGridMessage
            {
                From = new EmailAddress(vm.UserName, "KingPim Reset Password")
            };
            // Add the receiver.
            msg.AddTo("malloryfraiche@gmail.com");
            // Add template id the email should use.
            msg.TemplateId = "63dce31a-4040-45d9-9a2b-a63495a16c5f";
            // Set the substitution tag value.
            msg.AddSubstitution("substitutionLink", callbackUrl);
            // Send the email async and get the response from API.
            var response = client.SendEmailAsync(msg).Result;
            TempData["CheckYourEmail"] = "Your reset password link was sent to your email.";
            return RedirectToAction(nameof(Index));            
        }

        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var usersName = user.UserName;
            var model = new LoginViewModel
            {
                UserName = usersName,
                Code = code
            };
            return View(model);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(vm.UserName);
                var result = await _userManager.ResetPasswordAsync(user, vm.Code, vm.Password);
                var success = result.Succeeded;
                TempData["PasswordResetSuccess"] = "Your password was successfully reset!";
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }
    }
}