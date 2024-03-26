using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCareHub.Data.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid ServiceId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid MainCategoryId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(300)]
        public string? Description { get; set; }

        public Service Service { get; set; }

        public User User { get; set; }

        public MainCategory MainCategory { get; set; }
    }
}
