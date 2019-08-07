using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.CompanyCatalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatlaSport.Services.CompanyManagment
{
    internal class CompanyManagmentService : ICompanyService
    {
        ICompanyContext _context;

        public CompanyManagmentService(ICompanyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Company>> GetCompanysAsync()
        {
            var dbcompanys = await _context.Companys.OrderBy(h => h.Id).ToListAsync();

            return dbcompanys;
        }

        public async Task<Company> GetCompanyAsync(int companyid)
        {
            var dbcompanys = await _context.Companys.Where(h => h.Id == companyid).ToArrayAsync();
            if (dbcompanys.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            //var companys = Mapper.Map<Company, CompanyRequest>(dbcompanys[0]);
            return dbcompanys[0];
        }

        public async Task<Company> CreateCompanyAsync(CompanyRequest companyrequest)
        {
            var dbcompany = await _context.Companys.Where(h => (h.Name == companyrequest.Name && h.City == companyrequest.Name)).ToArrayAsync();
            if (dbcompany.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var company = Mapper.Map<CompanyRequest, Company>(companyrequest);
            _context.Companys.Add(company);

            await _context.SaveChangesAsync();

            return company;
        }

        public async Task<Company> UpdateCompanyAsync(int companyid, CompanyRequest companyrequest)
        {
            var dbcompanys = await _context.Companys.Where(p => p.Name == companyrequest.Name && p.Id != companyid).ToArrayAsync();
            if (dbcompanys.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbcompanys = _context.Companys.Where(p => p.Id == companyid).ToArray();
            if (dbcompanys.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbcompany = dbcompanys[0];

            dbcompany.Name = companyrequest.Name;
            dbcompany.Address = companyrequest.Address;
            dbcompany.City = companyrequest.City;
            dbcompany.Country = companyrequest.Country;
            await _context.SaveChangesAsync();

            return dbcompany;
        }

        public async Task DeleteCompanyAsync(int companyid)
        {
            var dbcompanys = await _context.Companys.Where(p => p.Id == companyid).ToArrayAsync();
            if (dbcompanys.Length == 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            _context.Companys.Remove(dbcompanys[0]);
            await _context.SaveChangesAsync();
        }
    }
}
