using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Data.Models
{
    /// <summary>
    /// Represents a comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

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
        [StringLength(1000)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the time of publishing.
        /// </summary>
        [Required]
        public DateTime PublishedOn { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// Gets or sets the likes.
        /// </summary>
        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();
    }
}
