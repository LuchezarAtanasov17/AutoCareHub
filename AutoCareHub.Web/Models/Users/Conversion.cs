using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Web.Models.Users
{
    public class Conversion
    {
        public static UserViewModel ConvertUser(ENTITIES.User source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new UserViewModel()
            {
                Id = source.Id,
                UserName = source.UserName,
                Email = source.Email,
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
            };

            return target;
        }
    }
}
