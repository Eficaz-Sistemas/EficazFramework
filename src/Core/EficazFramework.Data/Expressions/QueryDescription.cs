using EficazFramework.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EficazFramework.Expressions;

public class QueryDescription
{
    [JsonConstructor]
    public QueryDescription()
    { }

    public QueryDescription(ExpressionQuery filter, IEnumerable<SortDescription> orderBy)
    {
        Filter = filter;
        OrderBy.AddRange(orderBy);
    }

    public ExpressionQuery Filter { get; set; } = null;
    public List<SortDescription> OrderBy { get; set; } = new();
}
