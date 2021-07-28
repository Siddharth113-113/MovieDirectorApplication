using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDirectorApplicationAPP.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            return View();
        }
        public IActionResult UpdateMovie()
        {
            return View();
        }
        public IActionResult DeleteMovie()
        {
            return View();
        }

    }
}
