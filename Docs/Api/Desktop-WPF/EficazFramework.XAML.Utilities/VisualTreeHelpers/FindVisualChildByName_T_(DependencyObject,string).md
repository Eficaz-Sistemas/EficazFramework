#### [EficazFramework.WPF](EficazFrameworkWPF.md 'EficazFramework WPF')
### [EficazFramework.XAML.Utilities](EficazFrameworkWPF.md#EficazFramework.XAML.Utilities 'EficazFramework.XAML.Utilities').[VisualTreeHelpers](EficazFramework.XAML.Utilities/VisualTreeHelpers.md 'EficazFramework.XAML.Utilities.VisualTreeHelpers')

## VisualTreeHelpers.FindVisualChildByName<T>(DependencyObject, string) Method

Helper para encontrar um objeto de nível inferior no VisualTree

```csharp
public static T FindVisualChildByName<T>(System.Windows.DependencyObject parent, string name)
    where T : System.Windows.DependencyObject;
```
#### Type parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName_T_(System.Windows.DependencyObject,string).T'></a>

`T`

O tipo do objeto a ser encontrado.
#### Parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName_T_(System.Windows.DependencyObject,string).parent'></a>

`parent` [System.Windows.DependencyObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyObject 'System.Windows.DependencyObject')

O objeto de nível superior no qual a pesquisa será iniciada

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName_T_(System.Windows.DependencyObject,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O nome do objeto a ser encontrado

#### Returns
[T](EficazFramework.XAML.Utilities/VisualTreeHelpers/FindVisualChildByName_T_(DependencyObject,string).md#EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName_T_(System.Windows.DependencyObject,string).T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName<T>(System.Windows.DependencyObject, string).T')  
T

### Remarks