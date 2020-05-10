using Invoice.DataAccess;
using Invoice.DataAccess.Models;
using Invoice.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invoice.BusinessLayer
{
    public class CompanyDetails:ICompanyDetails
    {
        private readonly IServiceScopeFactory _context;
        public CompanyDetails(IServiceScopeFactory invoiceContext)
        {
            _context = invoiceContext;
        }
        public Company CreateCompany(CompanyRequest companyDetails) {

            using (var scope = _context.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<InvoiceContext>();
                var company = new Company()
                {
                    CompanyName = companyDetails.CompanyName,
                    City = companyDetails.Address.City,
                    State = companyDetails.Address.State,
                    Streat = companyDetails.Address.Streat,
                    ZipCode = companyDetails.Address.ZipCode
                };
                db.Company.Add(company);
                db.SaveChanges();

                return company;
            }
        }

        public CompanyResponse GetCompanyDetails(int companyId) {
            using (var scope = _context.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<InvoiceContext>();
                var invoiceList = db.InvoiceDetails.Where(i => i.CompanyId ==companyId).ToList();
                var companyInvoiceDetails= new List<CompanyInvoice>();
                foreach (var invoice in invoiceList) {
                    var customerName = db.Customer.Where(c => c.Id == invoice.CustomerId).FirstOrDefault().Name;
                    var orderItem = db.OrderDetails.Where(o => o.InvoiceId == invoice.Id).ToList<OrderDetails>();
                    var productIds = orderItem.Select(p => p.ProuductId).ToArray<int>();
                    var product = db.Product.Where(p => productIds.Contains(p.Id)).ToList<DataAccess.Models.Product>();
                    var productItem = product.Join(orderItem, pro => pro.Id, order => order.ProuductId, (pro, order) => new Models.Product { Name = pro.Name, Price = pro.price, Quantity = order.Quantity }).ToList();
                    var totalAmount = productItem.Select(s => s.Price * s.Quantity).ToArray<double>().Sum();
                    companyInvoiceDetails.Add(new CompanyInvoice { InvoiceNumber = invoice.InvoiceNumber, CustomerName = customerName, TotallAmount = totalAmount });
                }
               
                return new CompanyResponse { companyInvoice=companyInvoiceDetails};
            }
        }
    }
}
