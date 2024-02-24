using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCareHub.Data.Models
{
    public class MainCategoryService
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid MainCategoryId { get; set; }

        [Required]
        public Guid ServiceId { get; set; }

        public MainCategory MainCategory { get; set; }

        public Service Service { get; set; }
    }
}
