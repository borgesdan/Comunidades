using System.ComponentModel;

namespace Comunidades.ApiService.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Obtém o valor do atributo Description caso seja implememntado pela enumeração.
        /// </summary>
        public static string GetDescription(this Enum value)
        {
            try
            {
                var enumType = value.GetType();
                var nameName = Enum.GetName(enumType, value);
                var memberInfos = enumType.GetMember(nameName!);
                var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                var valueAttributes = enumValueMemberInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)valueAttributes[0]).Description;

                return description;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
