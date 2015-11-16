using System;
using System.Diagnostics;

namespace Mathos
{
    /// <summary>
    /// A utility class for benchmarking.
    /// </summary>
    public class BenchmarkUtil
    {
        /// <summary>
        /// Perform an <paramref name="action"/> benchmark with <paramref name="iterations"/>.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        /// <param name="iterations">The amount of iterations.</param>
        /// <returns>The amount of time taken.</returns>
        public static double Benchmark(Action action, int iterations)
        {
            double time = 0;
            const int innerCount = 5;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            for (var i = 0; i < innerCount; i++)
                action.Invoke();

            var watch = Stopwatch.StartNew();

            for (var i = 0; i < iterations; i++)
            {
                action.Invoke();
                time += Convert.ToDouble(watch.ElapsedMilliseconds) / Convert.ToDouble(iterations);
            }

            return time;
        }
    }
}
