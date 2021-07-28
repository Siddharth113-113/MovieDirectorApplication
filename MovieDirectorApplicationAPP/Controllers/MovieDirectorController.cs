using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPP.Controllers
{
    public class MovieDirectorController : Controller
    {
        public IActionResult DirectorByMovie()
        {
            return View();
        }
        public IActionResult MovieByDirector()
        {
            return View();
        }
    }
}
