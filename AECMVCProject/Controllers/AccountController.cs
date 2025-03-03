using AECMVCProject.Models;
using AECMVCProject.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AECMVCProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //Open Page <a href="/Acccount/REgister">
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel userFromRequest) 
        {
            if (ModelState.IsValid)
            {
                //add database
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = userFromRequest.UserName;
                userModel.Address = userFromRequest.Address;
                userModel.PasswordHash = userFromRequest.Password;

                IdentityResult result=
                    await  userManager.CreateAsync(userModel, userFromRequest.Password);//wait finish block
                if (result.Succeeded)
                {
                    //assign to Role
                    await userManager.AddToRoleAsync(userModel, "Admin");
                    //create cookie
                    await signInManager.SignInAsync(userModel, false);//create cookie session cookie
                    return RedirectToAction("Index", "Department");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View("Register",userFromRequest);
        }


        //Action Login 
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserView userFromRequest)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userFromDataBase=
                    await  userManager.FindByNameAsync(userFromRequest.UserName);
                if(userFromDataBase != null)
                {
                    bool found=await userManager.CheckPasswordAsync(userFromDataBase, userFromRequest.Password);
                    if (found)
                    {
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("Address", userFromDataBase.Address));

                        await signInManager.SignInWithClaimsAsync(userFromDataBase, userFromRequest.RememberMe, Claims);
                        //await signInManager.SignInAsync(userFromDataBase, userFromRequest.RememberMe);
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "Invalid username and Password");
                //cookie
            }
            return View("Login",userFromRequest);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
