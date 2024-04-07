namespace AutoCareHub.Services.Likes
{
    /// <summary>
    /// Provides access to likes.
    /// </summary>
    public interface ILikeService
    {
        /// <summary>
        /// Handles liking comment.
        /// </summary>
        /// <param name="commentId">the comment ID</param>
        /// <param name="userId">the user ID</param>
        Task HandleLikeCommentAsync(Guid commentId, Guid userId);
    }
}
