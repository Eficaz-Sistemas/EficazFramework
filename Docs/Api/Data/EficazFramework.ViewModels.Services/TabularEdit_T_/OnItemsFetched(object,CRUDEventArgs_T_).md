#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services').[TabularEdit&lt;T&gt;](EficazFramework.ViewModels.Services/TabularEdit_T_.md 'EficazFramework.ViewModels.Services.TabularEdit<T>')

## TabularEdit<T>.OnItemsFetched(object, CRUDEventArgs<T>) Method

Uma vez que a edição é tabular, é preciso adicionar o tracking de alterações de propriedades a todos os items da coleção.

```csharp
private void OnItemsFetched(object sender, EficazFramework.Events.CRUDEventArgs<T> e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnItemsFetched(object,EficazFramework.Events.CRUDEventArgs_T_).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnItemsFetched(object,EficazFramework.Events.CRUDEventArgs_T_).e'></a>

`e` [EficazFramework.Events.CRUDEventArgs&lt;](EficazFramework.Events/CRUDEventArgs_T_.md 'EficazFramework.Events.CRUDEventArgs<T>')[T](EficazFramework.ViewModels.Services/TabularEdit_T_.md#EficazFramework.ViewModels.Services.TabularEdit_T_.T 'EficazFramework.ViewModels.Services.TabularEdit<T>.T')[&gt;](EficazFramework.Events/CRUDEventArgs_T_.md 'EficazFramework.Events.CRUDEventArgs<T>')