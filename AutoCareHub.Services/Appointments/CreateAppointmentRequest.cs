using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.Appointments
{
    /// <summary>
    /// Represents a create appointment request.
    /// </summary>
    public class CreateAppointmentRequest
    {
        /// <summary>
        /// Gets or sets the service ID.
        /// </summary>
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the main category ID.
        /// </summary>
        public Guid MainCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the service main categories.
        /// </summary>
        public List<ServiceMainCategory>? ServiceMainCategories { get; set; }
    }
}
