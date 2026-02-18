using System.Runtime.Serialization;

namespace CryptoTracker.WPF.Helpers.QueryParameters.Enums
{
    internal enum IncludeTokens
    {
        [EnumMember(Value = "top")]
        Top,
        [EnumMember(Value = "all")]
        All
    }
}
