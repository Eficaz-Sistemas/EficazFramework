#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels](EficazFrameworkData.md#EficazFramework_ViewModels 'EficazFramework.ViewModels').[ViewModel&lt;T&gt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')
## ViewModel&lt;T&gt;.BeginGet() Method
Executado antes dos métodos Get ou GetAsync do Repositório, permitindo interceptar algum parâmetro ou toda a operação  
```csharp
private EficazFramework.Events.CRUDEventArgs<T> BeginGet();
```
#### Returns
[EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](ViewModel_T_.md#EficazFramework_ViewModels_ViewModel_T__T 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')  
