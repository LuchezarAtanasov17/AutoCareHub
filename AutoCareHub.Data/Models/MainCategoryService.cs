using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCareHub.Data.Models
{
    /// <summary>
    /// Represents a main category service.
    /// </summary>
    public class MainCategoryService
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the main category ID.
        /// </summary>
        [Required]
        public Guid MainCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the service ID.
        /// </summary>
        [Required]
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the Main category.
        /// </summary>
        public MainCategory MainCategory { get; set; }

        /// <summary>
        /// Gets or sets the Service.
        /// </summary>
        public Service Service { get; set; }
    }
}
