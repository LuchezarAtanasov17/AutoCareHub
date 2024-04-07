using AutoCareHub.Services.Appointments;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Appointments
{
    /// <summary>
    /// Represents a conversion class for converting appointment models.
    /// </summary>
    internal class Conversion
    {
        #region Request To Entity

        /// <summary>
        /// Converts create service request to entity model.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the entity appointment</returns>
        /// <exception cref="ArgumentNullException"></exception>
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
