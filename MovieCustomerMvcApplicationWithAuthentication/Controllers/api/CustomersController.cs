using MovieCustomerMvcApplicationWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace MovieCustomerMvcApplicationWithAuthentication.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            // return _context.Customers.ToList();
            return customers;
        }


        public IHttpActionResult GetCustomer(int id)
        {

            if (id <= 0)
                return BadRequest("Not a valid customer id");

            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            return Ok(customer);
        }


        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model data is invalid");
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok(customer);
        }


        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
               // throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            customerInDb.Dob = customer.Dob;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            _context.SaveChanges();
            return Ok();

        }
        //DELETE /api/customers/1
        public  IHttpActionResult DeleteCustomer(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid customer id");
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}

