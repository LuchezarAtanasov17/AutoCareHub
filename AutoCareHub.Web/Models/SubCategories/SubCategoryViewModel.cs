namespace AutoCareHub.Web.Models.SubCategories
{
    /// <summary>
    /// Represents a sub category view model.
    /// </summary>
    public class SubCategoryViewModel
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the main category ID.
        /// </summary>
        public Guid MainCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the main category name.
        /// </summary>
        public string MainCategoryName { get; set; }
    }
}
