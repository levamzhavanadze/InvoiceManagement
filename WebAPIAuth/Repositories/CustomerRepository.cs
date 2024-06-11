using WebAPIAuth.Data;
using WebAPIAuth.Interfaces;
using WebAPIAuth.Models.Customers;

namespace WebAPIAuth.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
           
            _context.customer.Add(customer);
            _context.SaveChanges();
            
        }

        public List<Customer> GetAll() 
        {
           var customers =  _context.customer.ToList();

            return customers;
        }

    }
}
