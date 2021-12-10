#### [EficazFramework.WPF](EficazFrameworkWPF.md 'EficazFramework WPF')
### [EficazFramework.XAML.Utilities](EficazFrameworkWPF.md#EficazFramework.XAML.Utilities 'EficazFramework.XAML.Utilities').[VisualTreeHelpers](VisualTreeHelpers.md 'EficazFramework.XAML.Utilities.VisualTreeHelpers')

## VisualTreeHelpers.FindVisualChild<T>(DependencyObject) Method

Helper para encontrar um objeto de nível inferior no VisualTree

```csharp
public static T FindVisualChild<T>(System.Windows.DependencyObject parent)
    where T : System.Windows.DependencyObject;
```
#### Type parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild_T_(System.Windows.DependencyObject).T'></a>

`T`

O tipo do objeto a ser encontrado.
#### Parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild_T_(System.Windows.DependencyObject).parent'></a>

`parent` [System.Windows.DependencyObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyObject 'System.Windows.DependencyObject')

O objeto de nível superior no qual a pesquisa será iniciada

#### Returns
[T](VisualTreeHelpers.FindVisualChild_T_(DependencyObject).md#EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild_T_(System.Windows.DependencyObject).T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild<T>(System.Windows.DependencyObject).T')  
T

### Remarks