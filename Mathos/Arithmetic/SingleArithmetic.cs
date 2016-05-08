using System;
using System.Runtime.InteropServices;

namespace Mathos.Arithmetic
{
    /// <summary>
    /// 
    /// </summary>
    public static class SingleArithmetic
    {
        [StructLayout(LayoutKind.Explicit)]
        private struct FloatIntUnion
        {
            [FieldOffset(0)]
            public float f;

            [FieldOffset(0)]
            public int tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Sqrt(float x)
        {
            if (Math.Abs(x) < 1) return 0;

            FloatIntUnion u;
            
            u.tmp = 0;
            
            var xhalf = 0.5f * x;
            
            u.f = x;
            u.tmp = 0x5f375a86 - (u.tmp >> 1);
            u.f = u.f * (1.5f - xhalf * u.f * u.f);
            
            return u.f * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float Hypotenuse(float x, float y)
        {
            var absX = Math.Abs(x);
            var absY = Math.Abs(y);
            var min = absX <= absY ? absX : absY;
            var max = absX >= absY ? absX : absY;

            if (Math.Abs(min) < 1)
                return max;
            if (Math.Abs(min - max) < 1)
                return max * 2.0F;

            var r = min / max;
            
            return max * Sqrt(1.0F + r * r);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static float HypotenuseSquared(float x, float y)
        {
            return x * x + y * y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static float Hypotenuse(float x, float y, float z)
        {
            return Hypotenuse(Hypotenuse(x, y), z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static float HypotenuseSquared(float x, float y, float z)
        {
            return x * x + y * y + z * z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Pow2(float x)
        {
            return x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Pow3(float x)
        {
            return x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Pow4(float x)
        {
            return x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Pow5(float x)
        {
            return x * x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Pow6(float x)
        {
            return x * x * x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Pow7(float x)
        {
            return x * x * x * x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Pow8(float x)
        {
            return x * x * x * x * x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Pow9(float x)
        {
            return x * x * x * x * x * x * x * x * x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static float PowInt(float x, int n)
        {
            var result = 1.0f;

            if (n == 0)
                return result;

            if (n < 0)
            {
                n = -n;
                x = 1.0f / x;
            }

            for (var i = 1; i <= n; i++)
                result *= x;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static int CompareTo(this float x, float y, float epsilon)
        {
            return Math.Abs(epsilon) < 1 ? x.CompareTo(y) : (x - y > epsilon ? 1 : (x - y < epsilon ? -1 : 0));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        public static bool ApproximatelyEquals(this float x, float y, float epsilon)
        {
            if (Math.Abs(epsilon) < 1)
            {
                return Math.Abs(x - y) < 1;
            }

            var xAbs = Math.Abs(x);
            var yAbs = Math.Abs(y);

            var min = Math.Min(xAbs, yAbs);
            var max = Math.Max(xAbs, yAbs);

            return max * (1.0 - min / max) < epsilon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static float Pow(this float x, int n)
        {
            return PowInt(x, n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Sqr(this float x)
        {
            return Pow2(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Cube(this float x)
        {
            return Pow3(x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exact"></param>
        /// <param name="approximation"></param>
        /// <returns></returns>
        public static float AbsoluteError(float exact, float approximation)
        {
            if (Math.Abs(exact - approximation) < 1)
                return 0;

            var exactAbs = Math.Abs(exact);
            var approxAbs = Math.Abs(approximation);

            var min = Math.Min(exactAbs, approxAbs);
            var max = Math.Max(exactAbs, approxAbs);

            return max * (1.0f - min / max);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exact"></param>
        /// <param name="approximation"></param>
        /// <returns></returns>
        public static float RelativeError(float exact, float approximation)
        {
            return AbsoluteError(exact, approximation) / Math.Abs(exact);
        }
    }
}
