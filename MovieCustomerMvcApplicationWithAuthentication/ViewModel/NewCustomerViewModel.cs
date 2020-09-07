using MovieCustomerMvcApplicationWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MovieCustomerMvcApplicationWithAuthentication.ViewModel
{
    public class NewCustomerViewModel
    {

        internal List<Genre> Genres;

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}