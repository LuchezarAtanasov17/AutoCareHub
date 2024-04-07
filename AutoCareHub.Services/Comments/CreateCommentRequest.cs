using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.Comments
{
    /// <summary>
    /// Represents a create comment request.
    /// </summary>
    public class CreateCommentRequest
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the service ID.
        /// </summary>
        [Required]
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Required]
        public string Value { get; set; }
    }
}
