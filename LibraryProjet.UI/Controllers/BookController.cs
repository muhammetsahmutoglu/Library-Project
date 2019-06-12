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
    public class BookController : BaseController
    {
        public IActionResult Add()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Account");

        }
        [HttpPost]
        public IActionResult Add(Book Data)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                service.BookService.Add(Data);
                return RedirectToAction("List","Book");
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Update(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                Book book = service.BookService.GetById(id);
                BookDTO data = new BookDTO();
                data.ID = book.ID;
                data.Name = book.Name;
                data.Description = book.Description;
                
              
                return View(data);
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public IActionResult Update(BookDTO data)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                Book book = service.BookService.GetById(data.ID);
                book.Name = data.Name;
                book.AuthorFullName = data.AuthorFullName;
                book.Description = data.Description;                
                book.UpdateDate = DateTime.Now;
                book.Status = LibraryProject.DAL.ORM.Enum.Status.Updated;
                service.BookService.Update(book);
                return RedirectToAction("List","Book");
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult List()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                List<Book> model = service.BookService.GetActive();
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
               Book book = service.BookService.GetById(id);
                book.Status = Status.Deleted;
                service.BookService.Update(book);
                return RedirectToAction("List", "Account");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}