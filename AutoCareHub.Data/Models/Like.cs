using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Data.Models
{
    /// <summary>
    /// Represents a like.
    /// </summary>
    public class Like
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
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the comment ID.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Comment))]
        public Guid CommentId { get; set; }

        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the Comment.
        /// </summary>
        public Comment? Comment { get; set; }
    }
}
