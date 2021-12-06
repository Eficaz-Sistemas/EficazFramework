using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Collections;

[ExcludeFromCodeCoverage]
public class SortDescription
{
    public string PropertyName { get; set; }
    public EficazFramework.Enums.Collection.SortOrientation Direction { get; set; }
}
