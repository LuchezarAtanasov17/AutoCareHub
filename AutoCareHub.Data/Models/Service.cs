using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCareHub.Data.Models
{
    /// <summary>
    /// Represents a service.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(50)]
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
        [StringLength(30)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [Required]
        [StringLength(70)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the open time.
        /// </summary>
        [Required]
        public TimeOnly OpenTime { get; set; }

        /// <summary>
        /// Gets or sets the close time.
        /// </summary>
        [Required]
        public TimeOnly CloseTime { get; set; }

        /// <summary>
        /// Gets or sets if the service is approved.
        /// </summary>
        [Required]
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the image urls.
        /// </summary>
        public string? ImageUrls { get; set; }

        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the service request.
        /// </summary>
        public ServiceRequest? ServiceRequest { get; set; }

        /// <summary>
        /// Gets or sets the Appointments.
        /// </summary>
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

        /// <summary>
        /// Gets or sets the Main category services.
        /// </summary>
        public ICollection<MainCategoryService> MainCategoryServices { get; set; } = new HashSet<MainCategoryService>();

        /// <summary>
        /// Gets or sets the Comments.
        /// </summary>
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
