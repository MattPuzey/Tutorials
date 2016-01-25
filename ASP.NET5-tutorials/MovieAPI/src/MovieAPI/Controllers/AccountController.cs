using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using MovieAPI.Models;
using MovieAPI.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieAPI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            var signInStatus = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
            if (signInStatus == SignInResult.Success)
            {
                return Redirect("/home");
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }


        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return Redirect("/home");
        }

    }
}