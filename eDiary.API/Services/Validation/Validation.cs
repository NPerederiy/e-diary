using System;
using System.Globalization;

namespace eDiary.API.Services.Validation
{
    public class Validate
    {
        private static readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        /// <summary>
        /// Verifies whether the provided argument is NULL or not
        /// </summary>
        /// <param name="param">An argument to verify</param>
        public static void NotNull(object param)
        {
            if (param == null) throw new Exception("Provided argument cannot be NULL");
        }

        /// <summary>
        /// Verifies whether the provided argument is NULL or not
        /// </summary>
        /// <param name="param">An argument to verify</param>
        /// <param name="paramName">The name of provided argument</param>
        public static void NotNull(object param, string paramName)
        {
            if (param == null)
            {
                throw new Exception($"{textInfo.ToTitleCase(paramName)} cannot be NULL");
            }
        }

        /// <summary>
        /// Verifies whether the provided argument length equals to the required length. 
        /// </summary>
        /// <param name="param">An argument to verify</param>
        /// <param name="length">Required length</param>
        public static void RequiredLength(string param, int length)
        {
            if (param.Length != length)
            {
                throw new Exception("Provided argument has incorrect length");
            }
        }

        /// <summary>
        /// Verifies whether the provided argument length equals to the required length. 
        /// </summary>
        /// <param name="param">An argument to verify</param>
        /// <param name="length">Required length</param>
        /// <param name="paramName">The name of provided argument</param>
        public static void RequiredLength(string param, int length, string paramName)
        {
            if (param.Length != length)
            {
                throw new Exception($"{textInfo.ToTitleCase(paramName)} has incorrect length");
            }
        }
    }
}
