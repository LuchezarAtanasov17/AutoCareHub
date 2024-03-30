namespace AutoCareHub.Services.Likes
{
    public interface ILikeService
    {
        Task HandleLikePostAsync(Guid commentId, Guid userId);
    }
}
