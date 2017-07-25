namespace Mathos.Arithmetic.Numbers
{
    /// <summary>
    /// 
    /// </summary>
    public class Convert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static long ToPositive(long num)
        {
            return num < 0 ? num*-1 : num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static long ToNegative(long num)
        {
            return num > 0 ? num*-1 : num;
        }
    }
}