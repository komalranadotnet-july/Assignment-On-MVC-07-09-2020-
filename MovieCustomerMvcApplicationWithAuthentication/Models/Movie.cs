using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMvcApplicationWithAuthentication.Models
{
    public class Movie
    {

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Movie Name is mandatory")]
        [StringLength(40, ErrorMessage = "Movies Name should not exceed 40")]

        public string Name { get; set; }


        public DateTime ReleaseDate { get; set; }

        [Range (1, 20, ErrorMessage="Stock should be between 1 and 20")]
        public int Stock { get; set; }
        public Genre Genre { get; set; }

        public int GenreId { get; set; }
        public byte NumberAvailable { get; set; }


    }
}