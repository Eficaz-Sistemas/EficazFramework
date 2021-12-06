using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Attributes.UIEditor.EditorGeneration;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Property)]
public class IgnoreAttribute : Attribute
{
}
