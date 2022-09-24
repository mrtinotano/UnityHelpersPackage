using System;
using UnityEngine;

namespace Utilities
{
    [AttributeUsage(
        AttributeTargets.Field |
        AttributeTargets.Property |
        AttributeTargets.Class |
        AttributeTargets.Struct,
        Inherited = true)]
    public class EnumOptionShowAttribute : PropertyAttribute
    {
        public string EnumName;
        public string OptionName;

        public EnumOptionShowAttribute(string enumName, string optionName)
        {
            EnumName = enumName;
            OptionName = optionName;
        }
    }
}
