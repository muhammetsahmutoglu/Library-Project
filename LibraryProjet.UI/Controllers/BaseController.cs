using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.BLL.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProjet.UI.Controllers
{
    
    public class BaseController : Controller
    {     
	
        protected EntityService service;

        public BaseController()
        {
            service = new EntityService();
        }
    }
}