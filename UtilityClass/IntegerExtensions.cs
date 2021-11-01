using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostAPI.UtilityClass
{
    public static class IntegerExtensions
    {
        public static int ParseInt(this string value)
        {
            return int.TryParse(value, out int parsedInt) ? parsedInt : 0;
        }

        public static int? ParseNullableInt(this string value)
        {
            return string.IsNullOrEmpty(value) ? null : (int?)value.ParseInt();
        }
    }
}
