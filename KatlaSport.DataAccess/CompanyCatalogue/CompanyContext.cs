namespace KatlaSport.DataAccess.CompanyCatalogue
{
    internal sealed class CompanyContext : DomainContextBase<ApplicationDbContext>, ICompanyContext
    {
        public CompanyContext(ApplicationDbContext dbContext)
          : base(dbContext)
        {
        }

        public IEntitySet<Company> Companys => GetDbSet<Company>();
    }
}
