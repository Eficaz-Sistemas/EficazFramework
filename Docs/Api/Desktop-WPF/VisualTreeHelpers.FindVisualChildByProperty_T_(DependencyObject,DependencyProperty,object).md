#### [EficazFramework.WPF](EficazFrameworkWPF.md 'EficazFramework WPF')
### [EficazFramework.XAML.Utilities](EficazFrameworkWPF.md#EficazFramework.XAML.Utilities 'EficazFramework.XAML.Utilities').[VisualTreeHelpers](VisualTreeHelpers.md 'EficazFramework.XAML.Utilities.VisualTreeHelpers')

## VisualTreeHelpers.FindVisualChildByProperty<T>(DependencyObject, DependencyProperty, object) Method

Helper para encontrar um objeto de nível inferior no VisualTree, baseado no valor de uma  
dependencyProperty desejada.

```csharp
public static T FindVisualChildByProperty<T>(System.Windows.DependencyObject parent, System.Windows.DependencyProperty dp, object value)
    where T : System.Windows.DependencyObject;
```
#### Type parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByProperty_T_(System.Windows.DependencyObject,System.Windows.DependencyProperty,object).T'></a>

`T`

O tipo do objeto a ser encontrado.
#### Parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByProperty_T_(System.Windows.DependencyObject,System.Windows.DependencyProperty,object).parent'></a>

`parent` [System.Windows.DependencyObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyObject 'System.Windows.DependencyObject')

O objeto de nível superior no qual a pesquisa será iniciada.

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByProperty_T_(System.Windows.DependencyObject,System.Windows.DependencyProperty,object).dp'></a>

`dp` [System.Windows.DependencyProperty](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyProperty 'System.Windows.DependencyProperty')

DependencyProperty contendo o valor esperado.

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByProperty_T_(System.Windows.DependencyObject,System.Windows.DependencyProperty,object).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

O valor esperado para referenciar a busca.

#### Returns
[T](VisualTreeHelpers.FindVisualChildByProperty_T_(DependencyObject,DependencyProperty,object).md#EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByProperty_T_(System.Windows.DependencyObject,System.Windows.DependencyProperty,object).T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByProperty<T>(System.Windows.DependencyObject, System.Windows.DependencyProperty, object).T')

### Remarks