using System.Linq;
using System.Threading.Tasks;
using LearnAspNetCoreMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearnAspNetCoreMvc.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register () {
            return View (new Registration ());
        }

        [HttpPost]
        public async Task<IActionResult> Register (Registration registration) {
            if (!ModelState.IsValid) return View (registration);
            var newUser = new IdentityUser { Email = registration.EmailAddress, UserName = registration.EmailAddress };
            var result = await _userManager.CreateAsync (newUser, registration.Password);
            if (!result.Succeeded) {
                foreach (string error in result.Errors.Select (x => x.Description)) {
                    ModelState.AddModelError ("", error);
                }
                return View ();
            }
            return RedirectToAction ("Login");
        }

        [HttpGet]
        public IActionResult Login () {
            return View (new Login ());
        }

        [HttpPost]
        public async Task<IActionResult> Login (Login login, string returnUrl = null) {
            if (!ModelState.IsValid) {
                return View ();
            }
            var result = await _signInManager.PasswordSignInAsync (
                login.EmailAddress, login.Password,
                login.RememberMe, false
            );

            if (!result.Succeeded) {
                ModelState.AddModelError ("", "Login error!");
                return View ();
            }

            if (string.IsNullOrWhiteSpace (returnUrl))
                return RedirectToAction ("Index", "Home");

            return Redirect (returnUrl);
        }
        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl=null){
            await _signInManager.SignOutAsync();
            if(string.IsNullOrWhiteSpace(returnUrl))return RedirectToAction("Index","Home");
            return Redirect(returnUrl);
        }

    }
}