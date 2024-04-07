using ENTITIES = AutoCareHub.Data.Models;
using WEB_USERS = AutoCareHub.Web.Models.Users;
using WEB_SERVICES = AutoCareHub.Web.Models.Services;

namespace AutoCareHub.Web.Models.Appointment
{
    /// <summary>
    /// Represents a conversion class for converting web models.
    /// </summary>
    public class Conversion
    {
        /// <summary>
        /// Converts a entity appointment to web appointment.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the web appointment</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static AppointmentViewModel ConvertAppointment(ENTITIES.Appointment source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new AppointmentViewModel()
            {
                Id = source.Id,
                MainCategoryId = source.MainCategoryId,
                UserId = source.UserId,
                ServiceId = source.ServiceId,
                Description = source.Description,
                Date = source.Date,
                User = WEB_USERS.Conversion.ConvertUser(source.User),
                Service = new WEB_SERVICES.ServiceViewModel
                {
                    Id = source.ServiceId,
                    UserId = source.UserId,
                    Name = source.Service.Name,
                    Description = source.Service.Description,
                    OpenTime = source.Service.OpenTime,
                    CloseTime = source.Service.CloseTime,
                    City = source.Service.City,
                    Address = source.Service.Address,
                },
            };

            return target;
        }
    }
}
