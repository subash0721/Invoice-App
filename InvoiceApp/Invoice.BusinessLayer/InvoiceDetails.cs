using Invoice.DataAccess;
using Invoice.DataAccess.Models;
using Invoice.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Invoice.BusinessLayer
{
    public class InvoiceDetail:IInvoiceDetails
    {
        private readonly IServiceScopeFactory _context;
        public InvoiceDetail(IServiceScopeFactory invoiceContext)
        {
            _context = invoiceContext;
        }
        public InvoiceRequest CreateInvoice(InvoiceRequest invoiceRequest)
        {

            using (var scope = _context.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<InvoiceContext>();
                //add customer
                var newCustomer =new DataAccess.Models.Customer(){
                    Name = invoiceRequest.CustomerDetails.CustomerName,
                    Streat = invoiceRequest.CustomerDetails.ShippingDetails.Streat,
                    State = invoiceRequest.CustomerDetails.ShippingDetails.State,
                    City = invoiceRequest.CustomerDetails.ShippingDetails.City,
                    Phone= invoiceRequest.CustomerDetails.ShippingDetails.Phone,

                };
                db.Customer.Add(newCustomer);
                db.SaveChanges();
                //add products
                var invoice = new InvoiceDetails()
                {
                    InvoiceNumber = invoiceRequest.CompanyID.ToString()+"-"+ "DDYY",
                   CompanyId = invoiceRequest.CompanyID,
                    Date = invoiceRequest.InvoiceDate,
                    CustomerId = newCustomer.Id,
                   
                };
                db.InvoiceDetails.Add(invoice);
                db.SaveChanges();
                invoiceRequest.InvoiceId = invoice.Id;
                return invoiceRequest;
            }
        }
    }

}
