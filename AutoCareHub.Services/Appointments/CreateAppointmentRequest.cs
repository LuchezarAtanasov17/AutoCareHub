using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.Appointments
{
    public class CreateAppointmentRequest
    {
        public Guid ServiceId { get; set; }

        public Guid UserId { get; set; }

        public Guid MainCategoryId { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public List<ServiceMainCategory>? ServiceMainCategories { get; set; }
    }
}
