using WebAPIAuth.Models.Customers;

namespace WebAPIAuth.Models.Invoices
{
    public class Invoice
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public Customer customerId { get; set; }

        public string status { get; set; }

    }
}
