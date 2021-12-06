using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Attributes.UIEditor.EditorGeneration;

[ExcludeFromCodeCoverage]

[AttributeUsage(AttributeTargets.Property)]
public class FixedHeightAttribute : Attribute
{
    public double? Value { get; set; } = 0;
}
