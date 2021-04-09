using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videop.Models;
using Videop.ViewModels;
using System.Data.Entity;

namespace Videop.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            return View(viewModel);

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult(); 
            //return RedirectToAction("Index", "Home", new { page=1, sortBy="name" });
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        // movies
        public ActionResult Index()
        {
            // Parameter: (int? pageIndex, string sortBy)
            //if (!pageIndex.HasValue)
            //{
            //    pageIndex = 1; 
            //}

            //if (String.IsNullOrWhiteSpace(sortBy))
            //{
            //    sortBy = "Name";
            //}

            //var movie = GetMovies();

            ////return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
            //return View(movie);

            // Need: using System.Data.Entity;
            var movie = _context.Movies.Include(m => m.Genre).ToList();

            return View(movie);
        }

        // GET: Movies/New
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genre = genre
                //Movie = new Movie()
            };

            return View("MovieForm", viewModel);
        }

        // GET: Movies/Edit
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            // Now it take a constructor and generate all field
            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genres.ToList(),
                //Movie = movie
                // Initialize each prop or make a constructor in view model then initialize all there
                //Id = movie.Id,
                //Name = movie.Name,
                //ReleaseDate = movie.ReleaseDate,
                //NumberInStock = movie.NumberInStock,
                //GenreId = movie.GenreId
            };

            return View("MovieForm", viewModel);
        }

        // POST: Movies/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genres.ToList()                    
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var existMovie = _context.Movies.Single(m => m.Id == movie.Id);

                existMovie.Name = movie.Name;
                existMovie.ReleaseDate = movie.ReleaseDate;
                existMovie.NumberInStock = movie.NumberInStock;
                existMovie.GenreId = movie.GenreId;

                existMovie.DateAdded = DateTime.Now;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Name = "Conan" },
                new Movie { Name = "Naruto" }
            };
        }
    }
} 