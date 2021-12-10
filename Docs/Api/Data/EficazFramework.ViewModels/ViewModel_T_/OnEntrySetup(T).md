#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels](EficazFrameworkData.md#EficazFramework.ViewModels 'EficazFramework.ViewModels').[ViewModel&lt;T&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

## ViewModel<T>.OnEntrySetup(T) Method

Possibilita efetuar modificações nas entidades em ações específicas dos Serviços injetados.  
Considere configurar todas as entidades de Repository.DataContext quando o argumento entry for null.  
NOTA: Corresponde aos métodos PostProcessItem() e PostProcessCollection() da EficazFrameworkV3.

```csharp
public virtual System.Threading.Tasks.Task OnEntrySetup(T entry);
```
#### Parameters

<a name='EficazFramework.ViewModels.ViewModel_T_.OnEntrySetup(T).entry'></a>

`entry` [T](EficazFramework.ViewModels/ViewModel_T_.md#EficazFramework.ViewModels.ViewModel_T_.T 'EficazFramework.ViewModels.ViewModel<T>.T')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')