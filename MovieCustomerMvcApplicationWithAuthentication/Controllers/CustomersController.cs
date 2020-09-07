using Microsoft.Owin.Security.Provider;
using MovieCustomerMvcApplicationWithAuthentication.Models;
using MovieCustomerMvcApplicationWithAuthentication.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MovieCustomerMvcApplicationWithAuthentication.Controllers
{

    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customers
        //public ActionResult Index()
        //{
        //    var customers = _context.Customers.Include(c => c.MembershipType).ToList();
        //    return View(customers);
        //}
       
        
          public ActionResult Index()

        {

            IEnumerable<Customer> customers;

            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Customers").Result;

            customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            return View(customers);

        }


















        public ActionResult Details(int id)
        {
            var singleCustomer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (singleCustomer == null)
                return HttpNotFound();
            return View(singleCustomer);
        }


        //Display Form
        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        //Save the form





        [HttpPost]
            [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {

                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
                return View("New", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Dob = customer.Dob;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

       public ActionResult Edit(int id)
        {
            var updateCust = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (updateCust == null)
            {
                return HttpNotFound();
            }

            var vm = new NewCustomerViewModel
            {
                Customer = updateCust,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("New", vm);
        }

        public ActionResult Delete(int id)
        {
            Customer obj = _context.Customers.Find(id);
            _context.Customers.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}