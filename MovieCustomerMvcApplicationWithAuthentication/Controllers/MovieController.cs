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
        //    // GET: Movie
        //public ActionResult Index()
        //{
        //    var movies = _context.Movies.Include(g => g.Genre).ToList();

        //    if (User.IsInRole("CanManageMovie"))
        //    {

        //        return View("Index",movies);
        //    }
        //    else
        //    {


        //        return View("ReadOnlyIndex",movies);
        //    }

        //}



        public ActionResult Index()

        {
            IEnumerable<Movie> movies;

            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Movie").Result;

            movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            return View(movies);


        }



        public ActionResult Details(int id)
      {
                 
                    //    {
                    //        var singleMovie = _context.Movies.Include(g => g.Genre).SingleOrDefault(c => c.Id == id);
                   //        if (singleMovie == null)
                    //            return HttpNotFound();
                    //        return View(singleMovie);


            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync($"Movie/{id}").Result;
            Movie singleMovie;
            singleMovie = response.Content.ReadAsAsync<Movie>().Result;
            return View(singleMovie);

            }

            [HttpGet]
        [Authorize(Roles = "CanManageMovie")]


        public ActionResult New()
        {
            // var moviegenre = _context.Genres.ToList();
            HttpResponseMessage mresponse = GlobalVariables.webApiClient.GetAsync("GenreApi").Result;
            var moviegenre = mresponse.Content.ReadAsAsync<IEnumerable<Genre>>().Result;


            var viewModel = new NewMovieViewModel
            {
                Movie=new Movie(),
                Genres = moviegenre
            };
            return View("New",viewModel);
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

            //if (movie.Id == 0)
            //    _context.Movies.Add(movie);

            //else
            //{
            //    var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
            //    movieInDb.Name = movie.Name;
            //    movieInDb.Genre = movie.Genre;
            //}
            //_context.SaveChanges();
            //return RedirectToAction("Index", "Movie");



            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("GenreApi").Result;
            var moviegenre = response.Content.ReadAsAsync<IEnumerable<Genre>>().Result;
            HttpResponseMessage cresponse = GlobalVariables.webApiClient.GetAsync("Movie").Result;


            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movie,
                    Genres = moviegenre
                };
                return View("New", viewModel);
            };
            if (movie.Id == 0)
                cresponse = GlobalVariables.webApiClient.PostAsJsonAsync("Movie", movie).Result;
            else
            {
                cresponse = GlobalVariables.webApiClient.PutAsJsonAsync($"Movie/{movie.Id}", movie).Result;
            }

            return RedirectToAction("Index");


}

        public ActionResult Edit(int id)
        {
            //var updateMovie = _context.Movies.SingleOrDefault(m => m.Id == id);
            //if (updateMovie == null)
            //{
            //    return HttpNotFound();
            //}

            //var vm = new NewMovieViewModel
            //{
            //    Movie = updateMovie,
            //    Genres = _context.Genres.ToList()
            //};

            //return View("New", vm);


            //HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync($"Movie/{id}").Result;
            //Movie singleMovie;
            //singleMovie = response.Content.ReadAsAsync<Movie>().Result;
            //return View(singleMovie);

            HttpResponseMessage mResponse = GlobalVariables.webApiClient.GetAsync("GenreApi").Result;
            HttpResponseMessage cResponse = GlobalVariables.webApiClient.GetAsync($"Movie/{id}").Result;
            var vm = new NewMovieViewModel
            {
                Movie = cResponse.Content.ReadAsAsync<Movie>().Result,
              Genres = mResponse.Content.ReadAsAsync<IEnumerable<Genre>>().Result
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