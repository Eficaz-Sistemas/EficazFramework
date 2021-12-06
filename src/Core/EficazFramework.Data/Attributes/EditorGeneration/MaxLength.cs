using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Attributes.UIEditor.EditorGeneration;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Property)]
public class MaxLengthAttribute : Attribute
{
    public MaxLengthAttribute(int lenght)
    {
        Length = lenght;
    }

    public int? Length { get; set; } = default;
}
