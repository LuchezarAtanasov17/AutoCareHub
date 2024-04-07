using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoCareHub.Data
{
    /// <summary>
    /// Represents a converter between timespan and time only values.
    /// </summary>
    public class TimeOnlyToTimeSpanConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="TimeOnlyToTimeSpanConverter"/> class.
        /// </summary>
        public TimeOnlyToTimeSpanConverter() : base(
               x => x.ToTimeSpan(),
               y => TimeOnly.FromTimeSpan(y))
        {

        }
    }
}
