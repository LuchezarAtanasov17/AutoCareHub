using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCareHub.Data.Models
{
    public class CategoryService
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid ServiceId { get; set; }

        public MainCategory Category { get; set; }

        public Service Service { get; set; }
    }
}
