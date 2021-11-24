using System;

namespace EficazFramework.Attributes.UIEditor.EditingState
{
    public class VisibleIfAttribute : Attribute
    {
        public VisibleIfAttribute(string propertyName, EficazFramework.Enums.eCompareMethod comparemethod, object expectedValue = null)
        {
            RelatedPropertyName = propertyName;
            CompareMethod = comparemethod;
            ExpectedValue = expectedValue;
        }

        public string RelatedPropertyName { get; set; }
        public EficazFramework.Enums.eCompareMethod CompareMethod { get; set; } = EficazFramework.Enums.eCompareMethod.Is;
        public object ExpectedValue { get; set; }
    }
}