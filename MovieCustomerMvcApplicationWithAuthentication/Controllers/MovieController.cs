using Microsoft.Owin.Security.Provider;
using MovieCustomerMvcApplicationWithAuthentication.Models;
using MovieCustomerMvcApplicationWithAuthentication.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace MovieCustomerMvcApplicationWithAuthentication.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(g => g.Genre).ToList();

            if (User.IsInRole("CanManageMovie"))
            {
               
                return View("Index",movies);
            }
            else
            {
               

                return View("ReadOnlyIndex",movies);
            }
            
        }



        //public ActionResult Index()

        //{
        //        IEnumerable<Movie> movies;

        //        HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Movie").Result;

        //        movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
        //        return View(movies);
            

        //}



          public ActionResult Details(int id)
        {
            var singleMovie = _context.Movies.Include(g => g.Genre).SingleOrDefault(c => c.Id == id);
            if (singleMovie == null)
                return HttpNotFound();
            return View(singleMovie);
        }


        [HttpGet]
        [Authorize(Roles = "CanManageMovie")]


        public ActionResult New()
        {
            var moviegenre = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = moviegenre
            };
            return View(viewModel);
        }

        //Save the form

        //[HttpPost]
        //public ActionResult Create(Movie movie) //Model Binding
        //{
        //    _context.Movies.Add(movie);

        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Movie");
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageMovie")]
        public ActionResult Save(Movie movie)

        {
            
            if (movie.Id == 0)
                _context.Movies.Add(movie);

            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var updateMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (updateMovie == null)
            {
                return HttpNotFound();
            }

            var vm = new NewMovieViewModel
            {
                Movie = updateMovie,
                Genres = _context.Genres.ToList()
            };

            return View("New", vm);
        }


        public ActionResult Delete(int id)
        {
            Movie obj = _context.Movies.Find(id);
            _context.Movies.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}