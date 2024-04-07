using AutoCareHub.Services.Appointments;
using AutoCareHub.Services.Comments;
using AutoCareHub.Web.Models.Comments;
using AutoCareHub.Web.Models.MainCategories;
using AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Services
{
    /// <summary>
    /// Represents a service view model.
    /// </summary>
    public class ServiceViewModel
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets user ID.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; } = null!;

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; } = null!;

        /// <summary>
        /// Gets or sets the open time.
        /// </summary>
        public TimeOnly OpenTime { get; set; }

        /// <summary>
        /// Gets or sets the close time.
        /// </summary>
        public TimeOnly CloseTime { get; set; }

        /// <summary>
        /// Gets or sets if the service is approved.
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the image URLs.
        /// </summary>
        public string[] ImageUrls { get; set; }

        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        public UserViewModel User { get; set; }

        /// <summary>
        /// Gets or sets the create appointment request.
        /// </summary>
        public CreateAppointmentRequest CreateAppointmentRequest { get; set; }

        /// <summary>
        /// Gets or sets the create comment request.
        /// </summary>
        public CreateCommentRequest CreateCommentRequest { get; set; }

        /// <summary>
        /// Gets or sets the main categories.
        /// </summary>
        public ICollection<MainCategoryViewModel> MainCategories { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
