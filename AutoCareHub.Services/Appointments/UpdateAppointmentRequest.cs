namespace AutoCareHub.Services.Appointments
{
    public class UpdateAppointmentRequest
    {
        public Guid UserId { get; set; }

        public Guid MainCategoryId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Description { get; set; }

        public string ServiceName { get; set; }
    }
}
