namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a request for creating and updating a hive section.
    /// </summary>
    public class UpdateHiveSectionRequest
    {
        /// <summary>
        /// Gets or sets a store hive name section.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a store hive code section.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a store hive id.
        /// </summary>
        public int StoreHiveId { get; set; }
    }
}
