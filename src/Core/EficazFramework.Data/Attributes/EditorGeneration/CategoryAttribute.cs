using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Attributes.UIEditor.EditorGeneration;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Property)]
public class CategoryAttribute : Attribute
{
    public CategoryAttribute(string DescriptionOrResource)
    {
        Description = DescriptionOrResource;
    }

    public string Description { get; set; } = null;
}
