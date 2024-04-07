using AutoCareHub.Services.MainCategories;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.SubCategories
{
    /// <summary>
    /// Represents the create sub category request.
    /// </summary>
    public class CreateSubCategoryRequest
    {
        /// <summary>
        /// Gets or sets the main category ID.
        /// </summary>
        [Required]
        public Guid MainCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the main categories.
        /// </summary>
        public List<SelectMainCategory>? MainCategories { get; set; }
    }
}
