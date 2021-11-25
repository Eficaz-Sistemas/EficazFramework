#### [EficazFramework.WPF](EficazFrameworkWPF.md 'EficazFramework WPF')
### [EficazFramework.XAML.Utilities](EficazFrameworkWPF.md#EficazFramework_XAML_Utilities 'EficazFramework.XAML.Utilities').[VisualTreeHelpers](VisualTreeHelpers.md 'EficazFramework.XAML.Utilities.VisualTreeHelpers')
## VisualTreeHelpers.FindVisualChildren&lt;T&gt;(DependencyObject, bool) Method
Helper para encontrar um ou mais objeto de nível inferior no VisualTree  
```csharp
public static System.Collections.Generic.IEnumerable<T> FindVisualChildren<T>(System.Windows.DependencyObject parent, bool lockonfirstlevel=false)
    where T : System.Windows.DependencyObject;
```
#### Type parameters
<a name='EficazFramework_XAML_Utilities_VisualTreeHelpers_FindVisualChildren_T_(System_Windows_DependencyObject_bool)_T'></a>
`T`  
O tipo do objeto a ser encontrado.
  
#### Parameters
<a name='EficazFramework_XAML_Utilities_VisualTreeHelpers_FindVisualChildren_T_(System_Windows_DependencyObject_bool)_parent'></a>
`parent` [System.Windows.DependencyObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyObject 'System.Windows.DependencyObject')  
O objeto de nível superior no qual a pesquisa será iniciada
  
<a name='EficazFramework_XAML_Utilities_VisualTreeHelpers_FindVisualChildren_T_(System_Windows_DependencyObject_bool)_lockonfirstlevel'></a>
`lockonfirstlevel` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](VisualTreeHelpers_FindVisualChildren_T_(DependencyObject_bool).md#EficazFramework_XAML_Utilities_VisualTreeHelpers_FindVisualChildren_T_(System_Windows_DependencyObject_bool)_T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildren&lt;T&gt;(System.Windows.DependencyObject, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable(Of T)
### Remarks
