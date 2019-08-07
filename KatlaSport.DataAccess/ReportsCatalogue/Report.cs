using KatlaSport.DataAccess.AccountantCatalogue;
using KatlaSport.DataAccess.CompanyCatalogue;

namespace KatlaSport.DataAccess.ReportsCatalogue
{
    public class Report
    {
        /// <summary>
        /// Gets or sets a product store item ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product ID.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets a product.
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// Gets or sets a location ID.
        /// </summary>
        public int AccountantId { get; set; }

        /// <summary>
        /// Gets or sets a
        /// </summary>
        public virtual Accountant Accountant { get; set; }
    }
}
