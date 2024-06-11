using WebAPIAuth.Data;
using WebAPIAuth.Interfaces;
using WebAPIAuth.Models.Invoices;

namespace WebAPIAuth.Repositories
{
    public class InvoiceRepository : IInvoice
    {
        private readonly DataContext _context;

        public InvoiceRepository(DataContext context)
        {
            _context = context;
        }

        public void AddInvoice(Invoice invoice)
        {
            _context.Add(invoice);
            _context.SaveChanges();
        }

    }
}
