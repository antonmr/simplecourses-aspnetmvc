using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleCourses.Data;
using SimpleCourses.Models;

namespace SimpleCourses.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserAuthController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            loginModel.LoginInvalid = "true";

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, 
                    loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    loginModel.LoginInvalid = string.Empty;
                } else
                {
                    loginModel.RememberMe = false;
                    ModelState.AddModelError(string.Empty, "Invalid attempt.");
                }
            }

            return PartialView("_UserLoginPartial", loginModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if(returnUrl is not null)
            {
                return LocalRedirect(returnUrl);
            } else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegistrationModel registrationModel)
        {
            registrationModel.RegistrationInvalid = "true";

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = registrationModel.Email,
                    Email = registrationModel.Email,
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    Address1 = registrationModel.Address1,
                    Address2 = registrationModel.Address2,
                    Postcode = registrationModel.PostCode,
                    PhoneNumber = registrationModel.PhoneNumber,
                };

                var result = await _userManager.CreateAsync(user, registrationModel.Password);
                if (result.Succeeded)
                {
                    registrationModel.RegistrationInvalid = string.Empty;
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return PartialView("_UserRegistrationPartial", registrationModel);
                }

                ModelState.AddModelError(string.Empty, "Registration attempt failed.");
            }

            return PartialView("_UserRegistrationPartial", registrationModel);
        }
    }
}
