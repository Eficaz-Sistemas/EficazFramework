#### [EficazFramework.WPF](EficazFrameworkWPF.md 'EficazFramework WPF')
### [EficazFramework.XAML.Utilities](EficazFrameworkWPF.md#EficazFramework_XAML_Utilities 'EficazFramework.XAML.Utilities').[VisualTreeHelpers](VisualTreeHelpers.md 'EficazFramework.XAML.Utilities.VisualTreeHelpers')
## VisualTreeHelpers.FindVisualChildByName&lt;T&gt;(DependencyObject, string) Method
Helper para encontrar um objeto de nível inferior no VisualTree  
```csharp
public static T FindVisualChildByName<T>(System.Windows.DependencyObject parent, string name)
    where T : System.Windows.DependencyObject;
```
#### Type parameters
<a name='EficazFramework_XAML_Utilities_VisualTreeHelpers_FindVisualChildByName_T_(System_Windows_DependencyObject_string)_T'></a>
`T`  
O tipo do objeto a ser encontrado.
  
#### Parameters
<a name='EficazFramework_XAML_Utilities_VisualTreeHelpers_FindVisualChildByName_T_(System_Windows_DependencyObject_string)_parent'></a>
`parent` [System.Windows.DependencyObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyObject 'System.Windows.DependencyObject')  
O objeto de nível superior no qual a pesquisa será iniciada
  
<a name='EficazFramework_XAML_Utilities_VisualTreeHelpers_FindVisualChildByName_T_(System_Windows_DependencyObject_string)_name'></a>
`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
O nome do objeto a ser encontrado
  
#### Returns
[T](VisualTreeHelpers_FindVisualChildByName_T_(DependencyObject_string).md#EficazFramework_XAML_Utilities_VisualTreeHelpers_FindVisualChildByName_T_(System_Windows_DependencyObject_string)_T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName&lt;T&gt;(System.Windows.DependencyObject, string).T')  
T
### Remarks
