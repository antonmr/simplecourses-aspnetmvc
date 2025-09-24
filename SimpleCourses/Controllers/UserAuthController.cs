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
    }
}
