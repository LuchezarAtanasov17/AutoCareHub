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
        public string Value { get; set; }
    }
}
