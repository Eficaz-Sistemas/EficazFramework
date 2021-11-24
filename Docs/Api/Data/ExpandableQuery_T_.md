#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework_Extensions 'EficazFramework.Extensions')
## ExpandableQuery&lt;T&gt; Class
An IQueryable wrapper that allows us to visit the query's expression tree just before LINQ to SQL gets to it.  
This is based on the excellent work of Tomas Petricek: http://tomasp.net/blog/linq-expand.aspx  
```csharp
public class ExpandableQuery<T> :
System.Linq.IQueryable<T>,
System.Collections.Generic.IEnumerable<T>,
System.Collections.IEnumerable,
System.Linq.IQueryable,
System.Linq.IOrderedQueryable<T>,
System.Linq.IOrderedQueryable
```
#### Type parameters
<a name='EficazFramework_Extensions_ExpandableQuery_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ExpandableQuery&lt;T&gt;  

Implements [System.Linq.IQueryable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1')[T](ExpandableQuery_T_.md#EficazFramework_Extensions_ExpandableQuery_T__T 'EficazFramework.Extensions.ExpandableQuery&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable-1 'System.Linq.IQueryable`1'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](ExpandableQuery_T_.md#EficazFramework_Extensions_ExpandableQuery_T__T 'EficazFramework.Extensions.ExpandableQuery&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [System.Linq.IQueryable](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IQueryable 'System.Linq.IQueryable'), [System.Linq.IOrderedQueryable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IOrderedQueryable-1 'System.Linq.IOrderedQueryable`1')[T](ExpandableQuery_T_.md#EficazFramework_Extensions_ExpandableQuery_T__T 'EficazFramework.Extensions.ExpandableQuery&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IOrderedQueryable-1 'System.Linq.IOrderedQueryable`1'), [System.Linq.IOrderedQueryable](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IOrderedQueryable 'System.Linq.IOrderedQueryable')  
