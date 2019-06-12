using LibraryProject.BLL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.BLL.Service
{
    public class EntityService
    {
        public EntityService()
        {
            _appUserService = new AppUserRepository();
            _bookService = new BookRepository();
        }
        private AppUserRepository _appUserService;

        public AppUserRepository AppUserService
        {
            get { return _appUserService; }
            set { _appUserService = value; }
        }
        private BookRepository _bookService;

        public BookRepository BookService
        {
            get { return _bookService; }
            set { _bookService = value; }
        }
    }
}
