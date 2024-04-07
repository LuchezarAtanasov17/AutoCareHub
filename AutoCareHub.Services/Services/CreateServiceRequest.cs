using AutoCareHub.Services.MainCategories;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.Services
{
    /// <summary>
    /// Represents a create service request.
    /// </summary>
    public class CreateServiceRequest
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the main category IDs.
        /// </summary>
        public List<Guid>? MainCategoryIds { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [StringLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [Required]
        [StringLength(70, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the open time.
        /// </summary>
        [Required]
        public string OpenTime { get; set; }

        /// <summary>
        /// Gets or sets the close time.
        /// </summary>
        [Required]
        public string CloseTime { get; set; }

        /// <summary>
        /// Gets or sets the main categories.
        /// </summary>
        public List<SelectMainCategory> MainCategories { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        public List<IFormFile> Images { get; set; }
    }
}
