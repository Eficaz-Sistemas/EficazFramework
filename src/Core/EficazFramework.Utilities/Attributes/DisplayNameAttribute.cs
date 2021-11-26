using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
[ExcludeFromCodeCoverage]
public class DisplayNameAttribute : Attribute
{
    public DisplayNameAttribute(string DescriptionOrResource)
    {
        DisplayName = DescriptionOrResource;
    }

    public string DisplayName { get; set; } = null;
#nullable enable
    public Type? ResourceType { get; set; } = null;
#nullable disable

}
