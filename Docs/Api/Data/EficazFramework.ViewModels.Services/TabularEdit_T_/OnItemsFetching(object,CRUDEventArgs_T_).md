#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services').[TabularEdit&lt;T&gt;](EficazFramework.ViewModels.Services/TabularEdit_T_.md 'EficazFramework.ViewModels.Services.TabularEdit<T>')

## TabularEdit<T>.OnItemsFetching(object, CRUDEventArgs<T>) Method

Uma vez que a edição é tabular, é preciso remover o tracking de alterações de propriedades a todos os items da  
coleção antiga antes de uma nova pesquisa.

```csharp
private void OnItemsFetching(object sender, EficazFramework.Events.CRUDEventArgs<T> e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnItemsFetching(object,EficazFramework.Events.CRUDEventArgs_T_).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnItemsFetching(object,EficazFramework.Events.CRUDEventArgs_T_).e'></a>

`e` [EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](EficazFramework.ViewModels.Services/TabularEdit_T_.md#EficazFramework.ViewModels.Services.TabularEdit_T_.T 'EficazFramework.ViewModels.Services.TabularEdit<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')