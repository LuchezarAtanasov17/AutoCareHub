namespace AutoCareHub.Services.Ratings
{
    public interface IRatingService
    {
        Task UpdateServiceRatingAsync(UpdateRatingRequest request);
    }
}
