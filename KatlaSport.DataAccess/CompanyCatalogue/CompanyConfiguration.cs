using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.CompanyCatalogue
{
    internal sealed class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            ToTable("companys");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("company_id");
            Property(i => i.Name).HasColumnName("company_name");
            Property(i => i.Address).HasColumnName("company_address");
            Property(i => i.City).HasColumnName("company_city");
            Property(i => i.Country).HasColumnName("company_country");
        }
    }
}
