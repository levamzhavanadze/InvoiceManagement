using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIAuth.Interfaces;
using WebAPIAuth.Models.Customers;
using WebAPIAuth.Models.Users;

namespace WebAPIAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;
        private  Customer customer = new Customer();

        public CustomerController(ICustomer customer)
        {

            _customer = customer;
        }

        [HttpPost("Customer"), Authorize(Roles = "Admin")]
        public ActionResult<Customer> AddCustomer(CustomerDto request)
        {
            customer.Name = request.Name;
            customer.Email = request.Email;

            _customer.AddCustomer(customer);

            return Ok(customer);

        }

        [HttpGet("Customers"), Authorize(Roles = "Admin")]
        public ActionResult<Customer> GetAllCustomers()
        {
            var customers = _customer.GetAll();

            return Ok(customers);

        }


    }
}
