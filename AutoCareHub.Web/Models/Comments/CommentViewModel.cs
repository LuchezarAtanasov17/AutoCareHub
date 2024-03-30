﻿using AutoCareHub.Web.Models.Services;
using AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Comments
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }    

        public Guid UserId { get; set; }

        public Guid ServiceId { get; set; }

        public string Value { get; set; }

        public DateTime PublishedOn { get; set; }

        public bool CommentLikedByCurrentUser { get; set; }

        public int LikeCount { get; set; }

        public UserViewModel User { get; set; }

        public ServiceViewModel Service { get; set; }
    }
}
