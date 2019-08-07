namespace KatlaSport.DataAccess.ReportsCatalogue
{
    internal sealed class ReportContext : DomainContextBase<ApplicationDbContext>, IReportContext
    {
        public ReportContext(ApplicationDbContext dbContext)
           : base(dbContext)
        {
        }

        public IEntitySet<Report> Reports => GetDbSet<Report>();
    }
}