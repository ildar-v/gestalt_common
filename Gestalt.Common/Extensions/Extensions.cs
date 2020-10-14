using System;
using System.Diagnostics;

namespace Gestalt.Common.Extensions
{
    public static class Extensions
    {
        public static string DetailedTimeString(this Stopwatch sw)
        {
            var t = TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds);

            return
                $"{t.Hours.ToString():D2}h" +
                $":{t.Minutes.ToString():D2}m" +
                $":{t.Seconds.ToString():D2}s" +
                $":{t.Milliseconds.ToString():D3}ms";
        }
    }
}