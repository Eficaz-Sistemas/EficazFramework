using System;

namespace EficazFramework.Attributes.UIEditor.EditorGeneration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthAttribute : Attribute
    {
        public MaxLengthAttribute(int lenght)
        {
            Length = lenght;
        }

        public int? Length { get; set; } = default;
    }
}