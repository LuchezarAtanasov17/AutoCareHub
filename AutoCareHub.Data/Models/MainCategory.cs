using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Data.Models
{
    /// <summary>
    /// Represents a main category.
    /// </summary>
    public class MainCategory
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the Appointments.
        /// </summary>
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

        /// <summary>
        /// Gets or sets the Main category service.
        /// </summary>
        public ICollection<MainCategoryService> MainCategoryServices { get; set; } = new HashSet<MainCategoryService>();

        /// <summary>
        /// Gets or sets the Sub categories.
        /// </summary>
        public ICollection<SubCategory> SubCategories { get; set; } = new HashSet<SubCategory>();
    }
}
