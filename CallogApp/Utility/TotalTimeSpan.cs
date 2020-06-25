using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallogApp.Utility
{
    public static class TotalTimeSpan
    {
        public static TimeSpan TotalTime(this IEnumerable<TimeSpan> TheCollection)
        {
            int i = 0;
            int TotalSeconds = 0;

            var ArrayDuration = TheCollection.ToArray();

            for (i = 0; i < ArrayDuration.Length; i++)
            {
                TotalSeconds = (int)(ArrayDuration[i].TotalSeconds) + TotalSeconds;
            }

            return TimeSpan.FromSeconds(TotalSeconds);
        }
    }
}
