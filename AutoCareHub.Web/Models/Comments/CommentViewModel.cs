using AutoCareHub.Web.Models.Services;
using AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Comments
{
    public class CommentViewModel
    {
        public Guid UserId { get; set; }

        public Guid ServiceId { get; set; }

        public string Value { get; set; }

        public DateTime PublishedOn { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public UserViewModel User { get; set; }

        public ServiceViewModel Service { get; set; }
    }
}
