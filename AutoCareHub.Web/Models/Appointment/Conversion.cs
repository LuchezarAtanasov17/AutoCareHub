using ENTITIES = AutoCareHub.Data.Models;
using WEB_USERS = AutoCareHub.Web.Models.Users;
using WEB_SERVICES = AutoCareHub.Web.Models.Services;

namespace AutoCareHub.Web.Models.Appointment
{
    public class Conversion
    {
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
                StartDate = source.StartDate,
                EndDate = source.EndDate,
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
