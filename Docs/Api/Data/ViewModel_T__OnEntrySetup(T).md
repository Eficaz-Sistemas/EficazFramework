#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels](EficazFrameworkData.md#EficazFramework_ViewModels 'EficazFramework.ViewModels').[ViewModel&lt;T&gt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;')
## ViewModel&lt;T&gt;.OnEntrySetup(T) Method
Possibilita efetuar modificações nas entidades em ações específicas dos Serviços injetados.  
Considere configurar todas as entidades de Repository.DataContext quando o argumento entry for null.  
NOTA: Corresponde aos métodos PostProcessItem() e PostProcessCollection() da EficazFrameworkV3.  
```csharp
public virtual System.Threading.Tasks.Task OnEntrySetup(T entry);
```
#### Parameters
<a name='EficazFramework_ViewModels_ViewModel_T__OnEntrySetup(T)_entry'></a>
`entry` [T](ViewModel_T_.md#EficazFramework_ViewModels_ViewModel_T__T 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.T')  
  
#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
