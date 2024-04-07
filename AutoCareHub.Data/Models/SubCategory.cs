using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Data.Models
{
    /// <summary>
    /// Represents a sub category.
    /// </summary>
    public class SubCategory
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the main category ID.
        /// </summary>
        [Required]
        public Guid MainCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(70, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Main category.
        /// </summary>
        public MainCategory MainCategory { get; set; }
    }
}
