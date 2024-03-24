using AutoCareHub.Services.Appointments;
using AutoCareHub.Services.Comments;
using AutoCareHub.Web.Models.Comments;
using AutoCareHub.Web.Models.MainCategories;
using AutoCareHub.Web.Models.Ratings;
using AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Services
{
    public class ServiceViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string Location { get; set; } = null!;

        public TimeOnly OpenTime { get; set; }

        public TimeOnly CloseTime { get; set; }

        public string ImageUrl { get; set; }

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
