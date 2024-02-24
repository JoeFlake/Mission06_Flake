using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Flake.Models;
using System.Collections.Immutable;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieAdder", new MovieViewModel());
        }

        [HttpPost]
        public IActionResult MovieAdder(MovieViewModel response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else // Invalid data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            } 
        }

        public IActionResult Movies ()
        {
            // Linq
            var all_movies = _context.Movies
                .Include(x => x.Category)
                .ToList();

            return View(all_movies);
        }

        // Edit a movie
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieAdder", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(MovieViewModel updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }

        // Delete a movie
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieViewModel toDelete) 
        {
            _context.Movies.Remove(toDelete);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }
    }
}
