using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Data.Models
{
    public class MainCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

        public ICollection<CategoryService> CategoryServices { get; set; } = new HashSet<CategoryService>();

        public ICollection<SubCategory> SubCategories { get; set; } = new HashSet<SubCategory>();
    }
}
