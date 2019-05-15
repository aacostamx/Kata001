using System;
using System.Collections.Generic;
using System.Text;

namespace Kata001.Interface
{
    public interface IClockService
    {
        DateTimeOffset NowUTC { get; }
    }
}
