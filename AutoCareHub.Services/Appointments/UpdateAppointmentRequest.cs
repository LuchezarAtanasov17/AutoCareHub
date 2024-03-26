namespace AutoCareHub.Services.Appointments
{
    public class UpdateAppointmentRequest
    {
        public Guid UserId { get; set; }

        public Guid MainCategoryId { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public string ServiceName { get; set; }
    }
}
