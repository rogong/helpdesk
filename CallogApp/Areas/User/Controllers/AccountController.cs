using CallogApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CallogApp.Areas.User.Controllers
{
    [Area("User")]
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


        public IActionResult Register()
        {
            return RedirectToAction("Register", "Account", new { Area = "Identity" });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult ChangePassword()
        {
            if (!User.Identity.IsAuthenticated)
            {

                return RedirectToAction("Login", "Account", new { Area = "Identity" });

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {

                return RedirectToAction("Login", "Account", new { Area = "Identity" });

            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if(user == null)
                {
                    return RedirectToAction("Login", "Account", new { Area = "Identity" });
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if(!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                await _signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }

            return View(model);

        }

    }
}