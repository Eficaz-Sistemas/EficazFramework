#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories').[ApiRepository&lt;TEntity&gt;](EficazFramework.Repositories/ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository<TEntity>')

## ApiRepository<TEntity>.Cancel(object) Method

Solicita o cancelamento das alterações efetuadas no argumento item.  
Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext

```csharp
public override System.Exception Cancel(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.ApiRepository_TEntity_.Cancel(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')