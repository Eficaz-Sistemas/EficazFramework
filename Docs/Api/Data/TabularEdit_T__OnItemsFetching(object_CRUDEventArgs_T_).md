#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework_ViewModels_Services 'EficazFramework.ViewModels.Services').[TabularEdit&lt;T&gt;](TabularEdit_T_.md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;')
## TabularEdit&lt;T&gt;.OnItemsFetching(object, CRUDEventArgs&lt;T&gt;) Method
Uma vez que a edição é tabular, é preciso remover o tracking de alterações de propriedades a todos os items da  
coleção antiga antes de uma nova pesquisa.  
```csharp
private void OnItemsFetching(object sender, EficazFramework.Events.CRUDEventArgs<T> e);
```
#### Parameters
<a name='EficazFramework_ViewModels_Services_TabularEdit_T__OnItemsFetching(object_EficazFramework_Events_CRUDEventArgs_T_)_sender'></a>
`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
  
<a name='EficazFramework_ViewModels_Services_TabularEdit_T__OnItemsFetching(object_EficazFramework_Events_CRUDEventArgs_T_)_e'></a>
`e` [EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](TabularEdit_T_.md#EficazFramework_ViewModels_Services_TabularEdit_T__T 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')  
  
