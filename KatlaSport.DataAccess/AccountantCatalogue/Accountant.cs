using System.Collections.Generic;
using KatlaSport.DataAccess.ReportsCatalogue;

namespace KatlaSport.DataAccess.AccountantCatalogue
{
    public class Accountant
    {
        /// <summary>
        /// Gets or sets a accountant ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a accountant Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a accountant Surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets a accountant Age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets a accountant ChiefId.
        /// </summary>
        public int? ChiefId { get; set; }

        public string Photo { get; set; }

        public virtual Accountant Chief { get; set; }

        public virtual ICollection<Accountant> Accountants { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
