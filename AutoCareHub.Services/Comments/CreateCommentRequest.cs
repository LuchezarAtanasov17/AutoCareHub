using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.Comments
{
    public class CreateCommentRequest
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ServiceId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Value { get; set; }
    }
}
