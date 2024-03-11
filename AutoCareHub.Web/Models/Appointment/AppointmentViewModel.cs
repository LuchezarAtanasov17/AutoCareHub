using AutoCareHub.Web.Models.Services;
using AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Appointment
{
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }

        public Guid ServiceId { get; set; }

        public Guid UserId { get; set; }

        public Guid MainCategoryId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        public ServiceViewModel Service { get; set; }

        public UserViewModel User { get; set; }
    }
}
