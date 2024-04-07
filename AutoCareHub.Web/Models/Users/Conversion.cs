using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Web.Models.Users
{
    /// <summary>
    /// Represents a conversion class for converting web models.
    /// </summary>
    public class Conversion
    {
        /// <summary>
        /// Converts a entity user to web user.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the web user</returns>
        /// <exception cref="ArgumentNullException"></exception>
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
