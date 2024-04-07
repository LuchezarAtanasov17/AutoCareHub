namespace AutoCareHub.Services.MainCategories
{
    /// <summary>
    /// Represents a select main category.
    /// </summary>
    public class SelectMainCategory
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets if the main category is selected.
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
