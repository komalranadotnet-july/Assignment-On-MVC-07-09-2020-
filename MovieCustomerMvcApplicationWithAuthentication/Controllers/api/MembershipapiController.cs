using MovieCustomerMvcApplicationWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieCustomerMvcApplicationWithAuthentication.Controllers.api
{
    public class MembershipapiController : ApiController
    {
        ApplicationDbContext _context;
        public MembershipapiController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetAllMembershipTypes()
        {
            IEnumerable<MembershipType> membershipTypes;
            membershipTypes = _context.MembershipTypes.ToList();
            if (membershipTypes == null)
                return NotFound();
            return Ok(membershipTypes);
        }

    }
}
