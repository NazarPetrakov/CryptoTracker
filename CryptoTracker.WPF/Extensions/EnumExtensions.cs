using System.Runtime.Serialization;

namespace CryptoTracker.WPF.Extensions
{
    internal static class EnumExtensions
    {
        public static string? ToApiString(this Enum? value)
        {
            if (value is null)
                return null;

            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
            return ((EnumMemberAttribute)attributes[0]).Value;
        }
    }
}
