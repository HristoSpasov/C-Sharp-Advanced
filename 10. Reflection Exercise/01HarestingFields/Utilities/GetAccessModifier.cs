using _01HarestingFields.Enums;
using System.Reflection;

namespace _01HarestingFields.Utilities
{
    public static class GetAccessModifier
    {
        public static string ReturnAccessModifier(FieldInfo field)
        {
            string accessModifier = string.Empty;

            if (field.IsPrivate)
            {
                accessModifier = AccessModifierEnum.Private.ToString().ToLower();
            }

            if (field.IsFamily)
            {
                accessModifier = AccessModifierEnum.Protected.ToString().ToLower();
            }

            if (field.IsPublic)
            {
                accessModifier = AccessModifierEnum.Public.ToString().ToLower();
            }

            return accessModifier;
        }
    }
}