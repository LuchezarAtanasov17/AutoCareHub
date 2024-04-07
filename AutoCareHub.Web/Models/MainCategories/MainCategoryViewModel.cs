using AutoCareHub.Web.Models.SubCategories;

namespace AutoCareHub.Web.Models.MainCategories
{
    /// <summary>
    /// Represents a main category view model.
    /// </summary>
    public class MainCategoryViewModel
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
        /// Gets or sets the sub categories.
        /// </summary>
        public ICollection<SubCategoryViewModel> SubCategories { get; set; }
    }
}
