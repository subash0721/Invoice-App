using Invoice.DataAccess;
using Invoice.DataAccess.Models;
using Invoice.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
    }
}
