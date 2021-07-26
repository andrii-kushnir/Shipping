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
            int parsedInt;
            if (int.TryParse(value, out parsedInt))
            {
                return parsedInt;
            }

            return 0;
        }

        public static int? ParseNullableInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            return value.ParseInt();
        }
    }
}
