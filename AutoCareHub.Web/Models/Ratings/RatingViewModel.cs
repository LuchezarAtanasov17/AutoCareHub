using AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Ratings
{
    public class RatingViewModel
    {
        public Guid UserId { get; set; }

        public Guid ServiceId { get; set; }

        public int Value { get; set; }

        public UserViewModel User { get; set; }
    }
}
