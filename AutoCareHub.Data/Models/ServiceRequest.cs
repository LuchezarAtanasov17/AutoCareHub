using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Data.Models
{
    /// <summary>
    /// Represents a service request.
    /// </summary>
    public class ServiceRequest
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the service ID.
        /// </summary>
        [Required]
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the Service.
        /// </summary>
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

        /// <summary>
        /// Gets or sets the date of creation.
        /// </summary>
        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
