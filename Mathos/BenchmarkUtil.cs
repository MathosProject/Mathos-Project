using System;
using System.Diagnostics;

namespace Mathos.Testing
{
    /// <summary>
    /// 
    /// </summary>
    public class BenchmarkUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public static double Benchmark(Action action,
            int iterations)
        {
            double time = 0;
            const int innerCount = 5;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            for (var i = 0; i < innerCount; i++)
            {
                action.Invoke();
            }

            var watch = Stopwatch.StartNew();

            for (var i = 0; i < iterations; i++)
            {
                action.Invoke();
                time += Convert.ToDouble(watch.ElapsedMilliseconds) /
                    Convert.ToDouble(iterations);
            }

            return time;
        }
    }
}
