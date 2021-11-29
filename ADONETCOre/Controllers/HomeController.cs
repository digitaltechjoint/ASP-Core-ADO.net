using ADONETCOre.DataLayer;
using ADONETCOre.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ADONETCOre.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CustomerDAL _CustomerDAL = new CustomerDAL();
            List<Customers> CustomerList = new List<Customers>();
            CustomerList = _CustomerDAL.GetAllCustomers();


            return View(CustomerList);
        }

        [HttpPost]
        public IActionResult SearchCustomer(int CustomerId)
        {
            CustomerDAL _CustomerDAL = new CustomerDAL();
            List<Customers> CustomerList = new List<Customers>();
            CustomerList = _CustomerDAL.GetCustomerById(CustomerId);


            return View("Index",CustomerList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
