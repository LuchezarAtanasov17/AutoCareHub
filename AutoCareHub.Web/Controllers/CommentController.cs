﻿using AutoCareHub.Services.Comments;
using AutoCareHub.Services.Likes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoCareHub.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;

        public CommentController(ICommentService commentService, ILikeService likeService)
        {
            _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            _likeService = likeService ?? throw new ArgumentNullException(nameof(likeService));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            Guid id,
            CreateCommentRequest request)
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

        public async Task<IActionResult> Delete(Guid id)
        {
            var comment = await _commentService.GetCommentAsync(id);

            var serviceId = comment.ServiceId;

            await _commentService.DeleteCommentAsync(id);

            return RedirectToAction("Get", "Service", new { id = serviceId });
        }

        [HttpPost]
        public async Task HandleLike(string commentId)
        {
            await _likeService.HandleLikeCommentAsync(Guid.Parse(commentId), Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
    }
}
