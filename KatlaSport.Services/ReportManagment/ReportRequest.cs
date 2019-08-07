namespace KatlaSport.Services.ReportManagment
{
    public class ReportRequest
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
        /// Gets or sets a location ID.
        /// </summary>
        public int AccountantId { get; set; }
    }
}
