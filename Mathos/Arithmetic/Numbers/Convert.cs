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
            return Check.IsNegative(num) ? num*-1 : num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static long ToNegative(long num)
        {
            return Check.IsPositive(num) ? num*-1 : num;
        }
    }
}