using KatlaSport.DataAccess.CompanyCatalogue;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.CompanyManagment
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompanysAsync();

        Task<Company> GetCompanyAsync(int companyid);

        Task<Company> CreateCompanyAsync(CompanyRequest accountant);

        Task<Company> UpdateCompanyAsync(int companyid, CompanyRequest updateAccountant);

        Task DeleteCompanyAsync(int companyid);
    }
}
