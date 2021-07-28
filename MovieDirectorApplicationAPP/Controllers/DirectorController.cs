using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPP.Controllers
{
    public class DirectorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddDirector()
        {
            return View();
        }
        public IActionResult UpdateDirector()
        {
            return View();
        }
        public IActionResult DeleteDirector()
        {
            return View();
        }
    }
}
