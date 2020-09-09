using MovieCustomerMvcApplicationWithAuthentication.Migrations;
using MovieCustomerMvcApplicationWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web;

namespace MovieCustomerMvcApplicationWithAuthentication.Controllers.api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }


      
        public IEnumerable<Movie> GetMovie()
        {
            var movie = _context.Movies.Include(g => g.Genre).ToList();
            // return _context.Movies.ToList();
            return movie;
        }


        public IHttpActionResult GetMovie(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid movie");
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            // throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(movie);

        }

        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
              return BadRequest("Model data is invalid");
          //  throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok(movie);
        }



        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

           // throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();

            //  throw new HttpResponseException(HttpStatusCode.NotFound);
            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.Stock = movie.Stock;

            movieInDb.Genre = movie.Genre;
           
            _context.SaveChanges();
            return Ok();


        }
        //DELETE /api/customers/1
        public IHttpActionResult DeleteMovie(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid movie");
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();

            //throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();


        }

    }
}
