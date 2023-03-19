using NewApps.Application.Common.Interfaces;

namespace NewApps.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
