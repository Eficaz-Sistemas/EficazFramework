using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Attributes.UIEditor.EditingState;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Property)]
public class VisibleIfAttribute : Attribute
{
    public VisibleIfAttribute(string propertyName, EficazFramework.Enums.CompareMethod comparemethod, object expectedValue = null)
    {
        RelatedPropertyName = propertyName;
        CompareMethod = comparemethod;
        ExpectedValue = expectedValue;
    }

    public string RelatedPropertyName { get; set; }
    public EficazFramework.Enums.CompareMethod CompareMethod { get; set; } = EficazFramework.Enums.CompareMethod.Is;
    public object ExpectedValue { get; set; }
}
