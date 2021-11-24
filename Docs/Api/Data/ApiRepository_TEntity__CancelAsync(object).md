#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories').[ApiRepository&lt;TEntity&gt;](ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;')
## ApiRepository&lt;TEntity&gt;.CancelAsync(object) Method
Solicita o cancelamento das alterações efetuadas no argumento item.  
Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext  
```csharp
public override System.Threading.Tasks.Task<System.Exception> CancelAsync(object item);
```
#### Parameters
<a name='EficazFramework_Repositories_ApiRepository_TEntity__CancelAsync(object)_item'></a>
`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
