using TaskManager.Application.Common.Interfaces.Services;

namespace TaskManager.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
