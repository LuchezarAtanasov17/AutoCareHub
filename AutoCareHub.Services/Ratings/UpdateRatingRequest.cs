namespace AutoCareHub.Services.Ratings
{
    public class UpdateRatingRequest
    {
        public Guid ServiceId { get; set; }

        public Guid UserId { get; set; }

        public int Value { get; set; }
    }
}
