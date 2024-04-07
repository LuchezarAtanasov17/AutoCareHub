using AutoCareHub.Services.MainCategories;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.Services
{
    /// <summary>
    /// Represents update service request.
    /// </summary>
    public class UpdateServiceRequest
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [StringLength(300)]
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
        /// Gets or sets the selected main categories.
        /// </summary>
        public List<SelectMainCategory> SelectMainCategory { get; set; }
    }
}
