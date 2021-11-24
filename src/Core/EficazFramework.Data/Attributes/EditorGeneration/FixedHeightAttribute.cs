using System;

namespace EficazFramework.Attributes.UIEditor.EditorGeneration;

[AttributeUsage(AttributeTargets.Property)]
public class FixedHeightAttribute : Attribute
{
    public double? Value { get; set; } = 0;
}
