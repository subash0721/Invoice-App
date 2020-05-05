using Invoice.DataAccess;
using Invoice.DataAccess.Models;
using Invoice.Models;


namespace Invoice.BusinessLayer
{
    public interface ICompanyDetails
    {
        Company CreateCompany(CompanyRequest company);
    }
}
