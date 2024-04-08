using AutoCareHub.Services.Comments;
using AutoCareHub.Services.Likes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoCareHub.Web.Controllers
{
    /// <summary>
    /// Represents a comment controller.
    /// </summary>
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;

        /// <summary>
        /// Initialize new instance of <see cref="CommentController"/> class.
        /// </summary>
        /// <param name="commentService">the comment service</param>
        /// <param name="likeService">the like service</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CommentController(ICommentService commentService, ILikeService likeService)
        {
            _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            _likeService = likeService ?? throw new ArgumentNullException(nameof(likeService));
        }

        /// <summary>
        /// Creates a comment.
        /// </summary>
        /// <param name="id">the service ID</param>
        /// <param name="request">the request for creating a comment</param>
        /// <returns>the details of the service view</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        public async Task<IActionResult> Create(
            Guid id,
            CreateCommentRequest request)
        {
            try
            {
                if (request is null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                request.UserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                request.ServiceId = id;

                await _commentService.CreateCommentAsync(request);

                return RedirectToAction("Get", "Service", new { id = request.ServiceId });

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Deletes a specified comment.
        /// </summary>
        /// <param name="id">the comment ID</param>
        /// <returns>the details of the service view</returns>
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var comment = await _commentService.GetCommentAsync(id);

                var serviceId = comment.ServiceId;

                await _commentService.DeleteCommentAsync(id);

                return RedirectToAction("Get", "Service", new { id = serviceId });
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Handles a comment like.
        /// </summary>
        /// <param name="commentId">the comment ID</param>
        [HttpPost]
        public async Task HandleLike(string commentId)
        {
            try
            {
                await _likeService.HandleLikeCommentAsync(Guid.Parse(commentId), Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
