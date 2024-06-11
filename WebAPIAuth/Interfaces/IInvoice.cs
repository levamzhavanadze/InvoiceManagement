using WebAPIAuth.Models.Invoices;

namespace WebAPIAuth.Interfaces
{
    public interface IInvoice
    {
        void AddInvoice(List<InvoiceItem> items);

        void PayInvoice();

        void CancelPayment();
    }
}
