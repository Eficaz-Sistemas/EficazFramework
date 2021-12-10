#### [EficazFramework.WPF](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.XAML.Utilities](EficazFrameworkData.md#EficazFramework.XAML.Utilities 'EficazFramework.XAML.Utilities').[VisualTreeHelpers](EficazFramework.XAML.Utilities/VisualTreeHelpers.md 'EficazFramework.XAML.Utilities.VisualTreeHelpers')

## VisualTreeHelpers.FindVisualChildren<T>(DependencyObject, bool) Method

Helper para encontrar um ou mais objeto de nível inferior no VisualTree

```csharp
public static System.Collections.Generic.IEnumerable<T> FindVisualChildren<T>(System.Windows.DependencyObject parent, bool lockonfirstlevel=false)
    where T : System.Windows.DependencyObject;
```
#### Type parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildren_T_(System.Windows.DependencyObject,bool).T'></a>

`T`

O tipo do objeto a ser encontrado.
#### Parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildren_T_(System.Windows.DependencyObject,bool).parent'></a>

`parent` [System.Windows.DependencyObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyObject 'System.Windows.DependencyObject')

O objeto de nível superior no qual a pesquisa será iniciada

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildren_T_(System.Windows.DependencyObject,bool).lockonfirstlevel'></a>

`lockonfirstlevel` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EficazFramework.XAML.Utilities/VisualTreeHelpers/FindVisualChildren_T_(DependencyObject,bool).md#EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildren_T_(System.Windows.DependencyObject,bool).T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildren<T>(System.Windows.DependencyObject, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable(Of T)

### Remarks