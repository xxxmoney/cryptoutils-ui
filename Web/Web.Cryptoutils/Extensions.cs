using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Cryptoutils.Models;

namespace Web.Cryptoutils
{
    internal static class Extensions
    {
        /// <summary>
        /// Gets point as string represantation "X Y".
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static string GetAsString(this Point point)
        {
            return $"{point.X} {point.Y}";
        }

        /// <summary>
        /// Gets point as string represantation "X Y".
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static string GetAsString(this CustomPoint point)
        {
            return $"{point.X} {point.Y}";
        }

    }
}
