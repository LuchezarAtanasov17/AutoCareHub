namespace AutoCareHub.Services.Likes
{
    public interface ILikeService
    {
        Task HandleLikeCommentAsync(Guid commentId, Guid userId);
    }
}
