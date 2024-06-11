using Microsoft.EntityFrameworkCore;
using WebAPIAuth.Models.Users;
using WebAPIAuth.Models.Customers;
using WebAPIAuth.Models.Invoices;
using WebAPIAuth.Models.Payment;


namespace WebAPIAuth.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Customer> customer { get; set; }
        //public DbSet<Invoice> invoice { get; set; }
        //public DbSet<InvoiceItem> invoiceItems { get; set; }
        //public DbSet<Payment> payment { get; set; }

    }
}
