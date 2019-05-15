using System;
using Kata001.Interface;
using NodaTime;

namespace Kata001.Services
{
    public class ClockService : IClockService
    {
        public DateTimeOffset NowUTC { get => SystemClock.Instance.GetCurrentInstant().InUtc().ToDateTimeOffset(); }
    }
}
