﻿using ENTITIES = AutoCareHub.Data.Models;
using WEB_USERS = AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Comments
{
    public class Conversion
    {
        public static CommentViewModel ConvertComment(ENTITIES.Comment source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new CommentViewModel()
            {
                UserId = source.UserId,
                ServiceId = source.ServiceId,
                Dislikes = source.Dislikes,
                Likes = source.Likes,
                PublishedOn = source.PublishedOn,
                User = WEB_USERS.Conversion.ConvertUser(source.User),
            };

            return target;
        }
    }
}