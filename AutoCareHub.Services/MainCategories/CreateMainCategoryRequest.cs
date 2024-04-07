using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.MainCategories
{
    /// <summary>
    /// Represents a create main category request.
    /// </summary>
    public class CreateMainCategoryRequest
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
