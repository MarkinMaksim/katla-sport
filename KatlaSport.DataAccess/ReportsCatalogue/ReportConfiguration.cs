using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ReportsCatalogue
{
    internal sealed class ReportConfiguration : EntityTypeConfiguration<Report>
    {
        public ReportConfiguration()
        {
            ToTable("report");
            HasKey(i => i.Id);
            HasRequired(i => i.Accountant).WithMany(i => i.Reports).HasForeignKey(i => i.AccountantId);
            HasRequired(i => i.Company).WithMany(i => i.Reports).HasForeignKey(i => i.CompanyId);
            Property(i => i.Id).HasColumnName("report_id");
            Property(i => i.CompanyId).HasColumnName("report_company_id");
            Property(i => i.AccountantId).HasColumnName("report_account_id");
        }
    }
}
