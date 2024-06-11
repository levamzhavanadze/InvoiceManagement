using WebAPIAuth.Data;
using WebAPIAuth.Interfaces;
using WebAPIAuth.Models.Customers;

namespace WebAPIAuth.Repositories
{
    public class CustomerRepository : ICustomer
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
          //  _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
           
            _context.customer.Add(customer);
            _context.SaveChanges();
            

        }
    }
}
