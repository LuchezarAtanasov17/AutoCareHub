using ENTITIES = AutoCareHub.Data.Models;
using WEB_MAIN_CATEGORIES = AutoCareHub.Web.Models.MainCategories;
using WEB_COMMENTS = AutoCareHub.Web.Models.Comments;
using WEB_USERS = AutoCareHub.Web.Models.Users;
using AutoCareHub.Services.Appointments;
using System.Text.Json;

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
                City = source.City,
                Address = source.Address,
                IsApproved = source.IsApproved,
                User = WEB_USERS.Conversion.ConvertUser(source.User),
                MainCategories = source.MainCategoryServices
                    .Select(x => x.MainCategory)
                    .Select(WEB_MAIN_CATEGORIES.Conversion.ConvertMainCategory)
                    .ToList(),
                Comments = source.Comments
                    .Select(WEB_COMMENTS.Conversion.ConvertComment)
                    .ToList(),
            };

            if (source.ImageUrls is not null)
            {
                target.ImageUrls = JsonSerializer.Deserialize<string[]>(source.ImageUrls)!;
            }

            return target;
        }

        public static ServiceMainCategory ConvertMainCategoryViewModelToServiceMainCategory(WEB_MAIN_CATEGORIES.MainCategoryViewModel request)
        {
            var target = new ServiceMainCategory()
            {
                Id = request.Id,
                Name = request.Name,
            };

            return target;
        }
    }
}
