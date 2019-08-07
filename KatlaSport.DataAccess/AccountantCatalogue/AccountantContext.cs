namespace KatlaSport.DataAccess.AccountantCatalogue
{
    internal sealed class AccountantContext : DomainContextBase<ApplicationDbContext>, IAccountantContext
    {
        public AccountantContext(ApplicationDbContext dbContext)
          : base(dbContext)
        {
        }

        public IEntitySet<Accountant> Accountants => GetDbSet<Accountant>();
    }
}
