using CallogApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Threading.Tasks;


namespace CallogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
       

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return RedirectToAction("Login", "Account", new { Area = "Identity" });
        }
        public IActionResult AccessDenied()
        {
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult ChangeUserPassword()
        {
            if (!User.Identity.IsAuthenticated && !User.IsInRole("Super Admin"))
            {

                return RedirectToAction("Login", "Account", new { Area = "Identity" });

            }

           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(ChangeUserPasswordViewModel model)
        {
            if (!User.Identity.IsAuthenticated && !User.IsInRole("Super Admin"))
            {

                return RedirectToAction("Login", "Account", new { Area = "Identity" });

            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
           // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation");
            }

            var result = await _userManager.ResetPasswordAsync(user, code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }


            return View(model);

        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

    }
}