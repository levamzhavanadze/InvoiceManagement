using WebAPIAuth.Models.Invoices;

namespace WebAPIAuth.Interfaces
{
    public interface IInvoice
    {
       void AddInvoice(Invoice invoice);

        //void PayInvoice();

        //void CancelPayment();
    }
}
