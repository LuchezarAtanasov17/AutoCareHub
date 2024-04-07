using AutoCareHub.Web.Models.Services;
using AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Comments
{
    /// <summary>
    /// Represents a comment view model.
    /// </summary>
    public class CommentViewModel
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the service ID.
        /// </summary>
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the time of publishing.
        /// </summary>
        public DateTime PublishedOn { get; set; }

        /// <summary>
        /// Gets or sets if the comment is liked by the current user.
        /// </summary>
        public bool CommentLikedByCurrentUser { get; set; }

        /// <summary>
        /// Gets or sets the like count.
        /// </summary>
        public int LikeCount { get; set; }

        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        public UserViewModel User { get; set; }

        /// <summary>
        /// Gets or sets the Service.
        /// </summary>
        public ServiceViewModel Service { get; set; }
    }
}
