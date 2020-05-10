using Invoice.DataAccess;
using Invoice.DataAccess.Models;
using Invoice.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
                var randumNumber = new Random();
                //add products
                var invoice = new InvoiceDetails()
                {
                    InvoiceNumber = invoiceRequest.CompanyID.ToString()+"-"+ "DDYY"+randumNumber.Next().ToString(),
                    CompanyId = invoiceRequest.CompanyID,
                    Date = invoiceRequest.InvoiceDate,
                    CustomerId = newCustomer.Id,     
                };
                db.InvoiceDetails.Add(invoice);
                db.SaveChanges();
                foreach (var product in invoiceRequest.ProductDetails)
                {
                    var newProduct = new DataAccess.Models.Product()
                    {
                        price = product.Price,
                        Name= product.Name
                    };
                    db.Product.Add(newProduct);
                    db.SaveChanges();
                    var newOrder = new OrderDetails()
                    {
                        ProuductId=newProduct.Id,
                        InvoiceId= invoice.Id,
                        Quantity = product.Quantity
                    };
                  db.OrderDetails.Add(newOrder);
                  db.SaveChanges();
                }
               
                invoiceRequest.InvoiceId = invoice.Id;
                return invoiceRequest;
            }
        }

        public InvoiceResponse GetInvoiceDetails(string invoiceNumber)
        {
            using (var scope = _context.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<InvoiceContext>();
                var invoice = db.InvoiceDetails.Where(x => x.InvoiceNumber == invoiceNumber).FirstOrDefault();
                var company = db.Company.Where(c => c.Id == invoice.CompanyId).Select(x => new CompanyRequest { CompanyName = x.CompanyName, Address = new Address { City = x.City, State = x.State, Country = x.Country } }).FirstOrDefault();
                var customer = db.Customer.Where(c => c.Id == invoice.CustomerId).Select(c=>new Models.Customer {CustomerName= c.Name, ShippingDetails= new Address { City=c.City,State=c.State,Country=c.Country} }).FirstOrDefault();
                var orderItem = db.OrderDetails.Where(o => o.InvoiceId == invoice.Id).ToList<OrderDetails>();
                var productIds = orderItem.Select(p => p.ProuductId).ToArray<int>();
                var product = db.Product.Where(p => productIds.Contains(p.Id)).ToList<DataAccess.Models.Product>();
                var productItem = product.Join(orderItem, pro => pro.Id, order => order.ProuductId, (pro, order) => new Models.Product { Name = pro.Name, Price = pro.price, Quantity = order.Quantity }).ToList();
                var invoiceResponse = new InvoiceResponse { InvoiceDate = invoice.Date, CompanyDetails = company,CustomerDetails=customer, ProductDetails= productItem };

                return invoiceResponse;
            }
        }
        }

}
