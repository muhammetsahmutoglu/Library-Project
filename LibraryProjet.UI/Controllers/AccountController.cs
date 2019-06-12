using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibraryProject.DAL.ORM.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProjet.UI.Controllers
{
    
    public class AccountController : BaseController
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AppUser data)
        {
            AppUser user = service.AppUserService.GetByDefault(x => x.UserName == data.UserName && x.Password == data.Password);
            if (user==null)
            {
                AppUser appUser = new AppUser();
                appUser.UserName = data.UserName;
                appUser.Password = data.Password;
                appUser.Email = data.Email;
                appUser.Role = LibraryProject.DAL.ORM.Enum.Role.Customer;
                service.AppUserService.Add(appUser);
                return RedirectToAction("Login");
            }
            return RedirectToAction("Login");
        }
        
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                
                RedirectToAction("Home");
               
            }

            return View();

        }
        [HttpPost]
        public IActionResult Login(AppUser user)
        {
           
            user = service.AppUserService.GetByDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (user == null)
            {
              

                return RedirectToAction("Register");
            }
            
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.UserName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            if (user.Role == LibraryProject.DAL.ORM.Enum.Role.Admin)
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, LibraryProject.DAL.ORM.Enum.Role.Admin.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                return RedirectToAction("Index", "Home");

            }
            if (user.Role==LibraryProject.DAL.ORM.Enum.Role.Customer)
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, LibraryProject.DAL.ORM.Enum.Role.Customer.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index", "Home");

            }

            return View();
            
        }
        
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}