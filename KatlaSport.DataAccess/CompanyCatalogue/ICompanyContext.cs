namespace KatlaSport.DataAccess.CompanyCatalogue
{
    public interface ICompanyContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Company"/> entities.
        /// </summary>
        IEntitySet<Company> Companys { get; }
    }
}
