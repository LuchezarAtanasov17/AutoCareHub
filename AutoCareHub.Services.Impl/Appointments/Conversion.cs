using AutoCareHub.Services.Appointments;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Appointments
{
    internal class Conversion
    {
        #region Request To Entity

        public static ENTITIES.Appointment ConvertAppointment(CreateAppointmentRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new ENTITIES.Appointment()
            {
                ServiceId = source.ServiceId,
                MainCategoryId = source.MainCategoryId,
                UserId = source.UserId,
                Date = source.Date,
                Description = source.Description,
            };

            return target;
        }

        #endregion
    }
}
