using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Daimiel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Daimiel.Controllers
{
    public class LoginController : Controller
    {
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([Bind] Ad_Login ad)
        {            

            return RedirectToPage("Home/Index.cshtml");


            //return View();

        }
    }
}