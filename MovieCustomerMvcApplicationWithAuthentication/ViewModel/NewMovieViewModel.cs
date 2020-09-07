using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieCustomerMvcApplicationWithAuthentication.Models;


namespace MovieCustomerMvcApplicationWithAuthentication.ViewModel
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}