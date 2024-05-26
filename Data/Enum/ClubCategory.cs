using System.ComponentModel.DataAnnotations;

namespace RunNetCoreWeb.Data.Enum
{
    public enum ClubCategory
    {
        RoadRunner,
        Womens,
        City,
        Trail,
        [Display(Name = "whatthe fuck@")]
        Endurance
    }
}

// using System.Reflection;
// using System.Runtime.Serialization;

// namespace RunNetCoreWeb.Data.Enum
// {
//     public enum ClubCategory
//     {
//         [EnumMember(Value = "A")]
//         RoadRunner,

//         [EnumMember(Value = "B")]
//         Womens,

//         [EnumMember(Value = "C")]
//         City,

//         [EnumMember(Value = "D")]
//         Trail,

//         [EnumMember(Value = "E")]
//         Endurance
//     }

//     public static class ClubCategoryExtensions
//     {
//         public static string GetEnumMemberValue(this ClubCategory value)
//         {
//             var enumType = value.GetType();
//             var enumMemberAttribute = enumType.GetMember(value.ToString())
//                 .First()
//                 .GetCustomAttribute<EnumMemberAttribute>();

//             return enumMemberAttribute.Value;
//         }
//     }
// }
