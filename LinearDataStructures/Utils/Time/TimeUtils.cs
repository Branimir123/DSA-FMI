using System;
using System.Diagnostics;

namespace Utils.Time
{
    public static class Measure
    {
        public static string Action(Action action)
        {
            var watch = new Stopwatch();
            watch.Start();

            action();

            watch.Stop();

            return watch.Elapsed.ToString();
        }
    }
}
