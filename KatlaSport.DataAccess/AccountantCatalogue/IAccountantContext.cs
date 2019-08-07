namespace KatlaSport.DataAccess.AccountantCatalogue
{
    /// <summary>
    /// Represents a context for accountant domain.
    /// </summary>
    public interface IAccountantContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Accountant"/> entities.
        /// </summary>
        IEntitySet<Accountant> Accountants { get; }
    }
}
