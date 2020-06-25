using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CallogApp.Data;
using CallogApp.Models;
using CallogApp.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CallogApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        // private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            ApplicationDbContext db,
           // IEmailSender emailSender
           RoleManager<IdentityRole> roleManager

           )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
            _roleManager = roleManager;
            //  _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public Department DepartmentId { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Name { get; set; }
            public string Department { get; set; }
            public string Title { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Super Admin"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Dashboard", "Home", new { Area = "User" });
                }
            }
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ViewData["DepartmentId"] = new SelectList(_db.Departments, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            string role = Request.Form["IdUserRole"].ToString();

            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            // var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
            ViewData["DepartmentId"] = new SelectList(_db.Departments, "Id", "Name");
            if (ModelState.IsValid)
                {
                    var user = new ApplicationUser
                    {
                        UserName = Input.Email,
                        Email = Input.Email,
                        Name = Input.Name,
                       
                        DepartmentId = Convert.ToInt32(Input.Department)

                    };
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        if (!await _roleManager.RoleExistsAsync(SD.SuperAdminUser))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.SuperAdminUser));
                        }
                        if (!await _roleManager.RoleExistsAsync(SD.AdminUser))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.AdminUser));
                        }                     
                        else
                        {
                            if (role == SD.AdminUser)
                            {
                                await _userManager.AddToRoleAsync(user, SD.AdminUser);
                            }
                            else
                            {
                                if (role == SD.SuperAdminUser)
                                {
                                    await _userManager.AddToRoleAsync(user, SD.SuperAdminUser);
                                }
                                else
                                {
                                   
                                    await _signInManager.SignInAsync(user, isPersistent: false);
                                _logger.LogInformation("User logged in.");
                                return RedirectToAction("Dashboard", "Home", new { Area = "User" });
                            }
                            }

                        }

                        _logger.LogInformation("User just created a new account.");
                    return LocalRedirect(returnUrl);
                    
                }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                
            
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
