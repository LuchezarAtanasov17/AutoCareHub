using ENTITIES = AutoCareHub.Data.Models;
using WEB_MAIN_CATEGORIES = AutoCareHub.Web.Models.MainCategories;
using WEB_COMMENTS = AutoCareHub.Web.Models.Comments;
using WEB_USERS = AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Services
{
    public class Conversion
    {
        public static ServiceViewModel ConvertService(ENTITIES.Service source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new ServiceViewModel()
            {
                Id = source.Id,
                UserId = source.UserId,
                Name = source.Name,
                Description = source.Description,
                OpenTime = source.OpenTime,
                CloseTime = source.CloseTime,
                Location = source.Location,
                ImageUrl = source.ImageUrl,
                User = WEB_USERS.Conversion.ConvertUser(source.User),
                //TODO:
                //UpdateRatingRequest = new UpdateRatingRequest
                //{
                //    ServiceId = source.Id,
                //    Value = (int)Math.Floor(source.AverageRating),
                //    AverageRating = Math.Round(source.AverageRating, 2),
                //},
                MainCategories = source.MainCategoryServices
                    .Select(x => x.MainCategory)
                    .Select(WEB_MAIN_CATEGORIES.Conversion.ConvertMainCategory)
                    .ToList(),
                Comments = source.Comments
                    .Select(WEB_COMMENTS.Conversion.ConvertComment)
                    .ToList(),
        };

            return target;
        }
}
}
