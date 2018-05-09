using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using The_Book_Cave.Models;
using The_Book_Cave.Services;
using The_Book_Cave.Models.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;

namespace The_Book_Cave.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = "Vinsamlegast fylltu inn í viðeigandi reiti";
                return View();
            }

            var user = new ApplicationUser 
            {
                UserName = model.Email, 
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                //The user is successfully registered
                //add the concatenated first and last name as fullname in claims
                await _userManager.AddClaimAsync(user, new Claim("Name", $"{model.FirstName} {model.LastName} {model.Address} {model.Book} {model.Image}"));
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [Authorize]
        public async Task <IActionResult> MyProfile()
        {   
          var user = await _userManager.GetUserAsync(User);

          return View(new ProfileViewModel {
              FirstName = user.FirstName,
              LastName = user.LastName,
              Image = user.Image,
              FavoriteBook = user.FavoriteBook,
              Address = user.Address
          });
        }

        [Authorize]
        [HttpGet]
       public async Task <IActionResult> EditProfile()
        {   
           var user = await _userManager.GetUserAsync(User);

          return View(new ProfileViewModel {
              FirstName = user.FirstName,
              LastName = user.LastName,
              Image = user.Image,
              FavoriteBook = user.FavoriteBook,
              Address = user.Address
          });
        } 

        [Authorize]
        [HttpPost]
       public async Task <IActionResult> EditProfile(ProfileViewModel model)
        {   

             var user = await _userManager.GetUserAsync(User);

              user.FirstName = model.FirstName;
              user.LastName = model.LastName;
              user.Image = model.Image;
              user.FavoriteBook = model.FavoriteBook;
              user.Address = model.Address;

              await _userManager.UpdateAsync(user);
          
            return RedirectToAction("MyProfile");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
    
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}