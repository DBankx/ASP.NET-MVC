using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCLearning.Models;
using MVCLearning.ViewModels;

namespace MVCLearning.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //verifies if the email is in use
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
           var user = await userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Json(true);
            } else
            {
                return Json($"Email {email} is already in use");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //create a new user
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    City = model.City
                };
                //This creates the user, by passing in the identity user and the password form the view model
                var result = await userManager.CreateAsync(user, model.Password);

                //if the user was succesfully created then sign in using the user and set if you want the cookie to be persistent or not
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                //if they are errors while creating the user display all the errors by adding the errors to the modelState
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //find the person the email belongs to
                var user = await userManager.FindByEmailAsync(model.Email);
                var password = await userManager.CheckPasswordAsync(user, model.Password);

                if (password)
                {
                    //sign in with the user
                    var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        } 
                        else
                        { 
                        return RedirectToAction("index", "home");
                        }
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login");
            }
            return View(model);
        }
    }
}


