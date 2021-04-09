using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Videop.Models;
using Videop.ViewModels;

namespace Videop.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            // This is a Disposable object
            _context = new ApplicationDbContext();
        }

        // We need to dispose this object so the best way is to override from the base class
        protected override void Dispose(bool disposing)
        {
            // How to delegate, instantiate, dispose object in dependecy injection framework
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                // Initialize to get default value with the correct type Id --> int[0] not string[""]
                //Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        // Model Binding, so mvc framework bind this model to the request data
        // The parameter must be the same type in the view
        // If you put parameter type Customer mvc framework will understand because all keys value in forms submit is type customer

        // We can create a new class as DTO (Data Transfare Object) with only the properties that we want to update
        // "UpdateCustomerDto" and this way you can safly use tool as AutoMapper to update all prop in Dto to your domain obj
        
        // Now it will validate and compare hidden fiel and the cookie values
        // Generate, encrypte, validate token is done by mvc
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            // To add validation:
            // 1- add data annotation on your props in the model domain
            // 2- add if (!ModelState.IsValid) to change the flow of the program so if it's not true return the same view
            // 3- add validation messages to the form          
            //-----------------------------------
            // For validation we use ModelState Dictionary for get action data and for model binding validation
            // Return the value that indicate if the value is valid (we put this value)
            // IsValid used to change the application flow
            // So if it's not valid i want to return the same view
            if (!ModelState.IsValid)
            {
                // We need viewModel cuz not throw error for the view it req.

                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _context.MembershipTypes.ToList()
                    // This is for hold the same values that customer entered it and not removed if page redirect or reload
                    //Customer = customer
                };

                return View("CustomerForm", viewModel);
            }
            
            if (customer.Id == 0)
            {
                // This is not writen to the DB it's just in memory
                // The DbContext has a change tracking mechanism so every time you add or any operation to it he will mark obj with process (add, delete, update)
                _context.Customers.Add(customer);
            }
            else
            {
                // Get it from DB so DbContext can see changes then save it
                // Single(): if customer not found it will throw an exception 
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // Two way to update DB: 
                // 1: this will update model based on key value pairs in request obj data
                // This way must add new value to all type properties if not it will open a security holes so someone can put a data if the form is not have all fields
                // TryUpdateModel(customerInDb, "", new string[] { "Name", "Email"});// list of prop just it will updated but if it renamed will break the app

                // 2:
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletters = customer.IsSubscribedToNewsletters;                

                // We can use AutoMapper
                // Mapper.Map(customer, customerInDb);
            }
            // To persist this changes
            _context.SaveChanges();
            // Now DbContext will generate based on this changes a sql statements at runtime and then it will run them on DB after go through all modified objects
            // All this changes are wraped in transaction (either all changes persisted together or nothing)
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // If customer is exist in DB will get it other wise will get null
            if (customer == null)
            {
                return HttpNotFound();
            }

            // Look on View New if it empty will look on Edit 
            // The model behined this New view is NewCustomerViewModel

            var viewModel = new CustomerFormViewModel(customer)
            {
                //Customer = customer,
                // Also we must initialize MembershipTypes cuz view use it in DDL
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        // GET: Customers
        public ViewResult Index()
        {
            // This prop. is DbSet Defined in DbContext so with this can get all customers from DB
            // When this line is excuted EF will not going to query data from DB (deffered execution)
            // The query will executed when we iterate over customer obj (in foreach in view)
            // We can immeditly excute the query using (.ToList())
            // ..........................................................
            // Eager Loading is to load Customer and MembershipType data in view using (Include())
            // Include() Need using System.Data.Entity;
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customer);
        }

        // GET: Customers/Details
        public ActionResult Details(int id)
        {
            // Cuz SingleOrDefault the query will immeditly excuted
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{ Id = 1, Name = "Samer"},
        //        new Customer{ Id = 2, Name = "Amer"}
        //    };
        //}

    }
}