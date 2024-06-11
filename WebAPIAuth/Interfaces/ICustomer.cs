using WebAPIAuth.Models.Customers;

namespace WebAPIAuth.Interfaces
{
    public interface ICustomer
    {

        void AddCustomer(Customer customer);

        List<Customer> GetAll();
    }
}
