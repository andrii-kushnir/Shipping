using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ApiUkrPost
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo.Length <= 0)) return GenericEnum.ToString();
            object[] attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attribs.Any() ? ((DescriptionAttribute)attribs.ElementAt(0)).Description : GenericEnum.ToString();
        }

        public static string GetEnumMember(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo.Length <= 0)) return GenericEnum.ToString();
            object[] attribs = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
            return attribs.Any() ? ((EnumMemberAttribute)attribs.ElementAt(0)).Value : GenericEnum.ToString();
        }
    }
}
