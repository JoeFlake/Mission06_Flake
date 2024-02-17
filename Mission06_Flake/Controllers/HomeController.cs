using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Flake.Models;
using System.Diagnostics;

namespace Mission06_Flake.Controllers
{
    public class HomeController : Controller
    {
        private MovieAdderContext _context;

        public HomeController(MovieAdderContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }
         public IActionResult JoelIntro()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieAdder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieAdder(MovieViewModel response)
        {
            _context.Movies.Add(response); // Add record to the database
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
