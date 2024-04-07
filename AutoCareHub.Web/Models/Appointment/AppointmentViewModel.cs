using AutoCareHub.Web.Models.Services;
using AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Appointment
{
    /// <summary>
    /// Represents an appointment view model.
    /// </summary>
    public class AppointmentViewModel
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public Guid Id { get; set; }

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
        /// Gets or sets the Service.
        /// </summary>
        public ServiceViewModel Service { get; set; }

        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        public UserViewModel User { get; set; }
    }
}
