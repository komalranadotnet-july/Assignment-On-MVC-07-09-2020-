using MovieCustomerMvcApplicationWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieCustomerMvcApplicationWithAuthentication.Controllers.api
{
    public class GenreApiController : ApiController
    {
        ApplicationDbContext _context;
        public GenreApiController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetAllGenres()
        {
            IEnumerable<Genre> genres;
            genres = _context.Genres.ToList();
            if (genres == null)
                return NotFound();
            return Ok(genres);
        }

    }
}
