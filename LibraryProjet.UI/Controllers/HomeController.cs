using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProjet.UI.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProjet.UI.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            BookVM model = new BookVM()
            {
                Books = service.BookService.GetActive(),
                user=service.AppUserService.GetByDefault(x=>x.UserName==HttpContext.User.Identity.Name),
            };
            return View(model);
        }
    }
}