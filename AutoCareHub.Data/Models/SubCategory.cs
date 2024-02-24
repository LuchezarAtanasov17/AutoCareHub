using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Data.Models
{
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid MainCategoryId { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        public MainCategory MainCategory { get; set; }
    }
}
