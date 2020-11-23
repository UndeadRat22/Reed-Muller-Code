namespace Codes.Infrastructure
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Forces the given value into the given [min:max] range
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double Clamp(this double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}