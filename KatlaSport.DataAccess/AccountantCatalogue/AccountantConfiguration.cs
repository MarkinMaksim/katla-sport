using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.AccountantCatalogue
{
    internal sealed class AccountantConfiguration : EntityTypeConfiguration<Accountant>
    {
        public AccountantConfiguration()
        {
            ToTable("accountants");
            HasKey(i => i.Id);
            HasRequired(i => i.Chief).WithMany(i => i.Accountants).HasForeignKey(i => i.ChiefId);
            Property(i => i.Id).HasColumnName("accountant_id");
            Property(i => i.Name).HasColumnName("accountant_name");
            Property(i => i.Surname).HasColumnName("accountant_surname");
            Property(i => i.Age).HasColumnName("accountant_age");
            Property(i => i.ChiefId).HasColumnName("accountant_chiefid");
            Property(i => i.Photo).HasColumnName("accountant_photo");
        }
    }
}
