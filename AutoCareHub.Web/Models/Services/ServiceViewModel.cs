using AutoCareHub.Services.Appointments;
using AutoCareHub.Services.Comments;
using AutoCareHub.Web.Models.Comments;
using AutoCareHub.Web.Models.MainCategories;
using AutoCareHub.Web.Models.Ratings;
using AutoCareHub.Web.Models.Users;
using System.Reflection.Metadata.Ecma335;

namespace AutoCareHub.Web.Models.Services
{
    public class ServiceViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string City { get; set; } = null!;

        public string Address { get; set; } = null!;

        public TimeOnly OpenTime { get; set; }

        public TimeOnly CloseTime { get; set; }

        public bool IsApproved { get; set; }

        public string[] ImageUrls { get; set; }

        //TODO: public UpdateRatingRequest UpdateRatingRequest { get; set; } ???????????

        public UserViewModel User { get; set; }

        public CreateAppointmentRequest CreateAppointmentRequest { get; set; }

        public CreateCommentRequest CreateCommentRequest { get; set; }

        public ICollection<MainCategoryViewModel> MainCategories { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public ICollection<RatingViewModel> Ratings { get; set; }

        //TODO: RATING?
    }
}
