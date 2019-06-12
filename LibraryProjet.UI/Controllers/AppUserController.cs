using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.DAL.ORM.Entity;
using LibraryProject.DAL.ORM.Enum;
using LibraryProjet.UI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProjet.UI.Controllers
{
    public class AppUserController : BaseController
    {
        public IActionResult Add()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login","Account");

        }
        [HttpPost]
        public IActionResult Add(AppUser Data)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                service.AppUserService.Add(Data);
                return Redirect("/AppUser/List");
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Update(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser appuser = service.AppUserService.GetById(id);
                AppUserDTO user = new AppUserDTO();
                user.ID = appuser.ID;
                user.FirstName = appuser.FirstName;
                user.LastName = appuser.LastName;
                user.Password = appuser.Password;
                user.UserName = appuser.UserName;
                user.Email = appuser.Email;
                user.Role = appuser.Role;
                return View(user);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public IActionResult Update(AppUserDTO data)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = service.AppUserService.GetById(data.ID);
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.Password = data.Password;
                user.UserName = data.UserName;
                user.Email = data.Email;
                user.UpdateDate = DateTime.Now;
                user.Status = Status.Updated;
                user.Role = data.Role;
                service.AppUserService.Update(user);
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult List()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                List<AppUser> model = service.AppUserService.GetActive();
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = service.AppUserService.GetById(id);
                user.Status = Status.Deleted;
                service.AppUserService.Update(user);
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}