using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoCareHub.Data
{
    public class TimeOnlyToTimeSpanConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyToTimeSpanConverter() : base(
               x => x.ToTimeSpan(),
               y => TimeOnly.FromTimeSpan(y))
        {

        }
    }
}
