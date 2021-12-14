#### [EficazFramework.WPF](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.XAML.Utilities](EficazFrameworkData.md#EficazFramework.XAML.Utilities 'EficazFramework.XAML.Utilities')

## VisualTreeHelpers Class

```csharp
public class VisualTreeHelpers
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; VisualTreeHelpers
### Methods

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor_T_(System.Windows.DependencyObject)'></a>

## VisualTreeHelpers.FindAnchestor<T>(DependencyObject) Method

Helper para encontrar um objeto de nível superior no VisualTree

```csharp
public static T FindAnchestor<T>(System.Windows.DependencyObject current)
    where T : System.Windows.DependencyObject;
```
#### Type parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor_T_(System.Windows.DependencyObject).T'></a>

`T`

O tipo do objeto a ser encontrado.
#### Parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor_T_(System.Windows.DependencyObject).current'></a>

`current` [System.Windows.DependencyObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyObject 'System.Windows.DependencyObject')

O objeto a ser encontrado

#### Returns
[T](EficazFramework.XAML.Utilities/VisualTreeHelpers.md#EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor_T_(System.Windows.DependencyObject).T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindAnchestor<T>(System.Windows.DependencyObject).T')  
Object

### Remarks

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild_T_(System.Windows.DependencyObject)'></a>

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
[T](EficazFramework.XAML.Utilities/VisualTreeHelpers.md#EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild_T_(System.Windows.DependencyObject).T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChild<T>(System.Windows.DependencyObject).T')  
T

### Remarks

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName_T_(System.Windows.DependencyObject,string)'></a>

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
[T](EficazFramework.XAML.Utilities/VisualTreeHelpers.md#EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName_T_(System.Windows.DependencyObject,string).T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByName<T>(System.Windows.DependencyObject, string).T')  
T

### Remarks

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByProperty_T_(System.Windows.DependencyObject,System.Windows.DependencyProperty,object)'></a>

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
[T](EficazFramework.XAML.Utilities/VisualTreeHelpers.md#EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByProperty_T_(System.Windows.DependencyObject,System.Windows.DependencyProperty,object).T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildByProperty<T>(System.Windows.DependencyObject, System.Windows.DependencyProperty, object).T')

### Remarks

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildren_T_(System.Windows.DependencyObject,bool)'></a>

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
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EficazFramework.XAML.Utilities/VisualTreeHelpers.md#EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildren_T_(System.Windows.DependencyObject,bool).T 'EficazFramework.XAML.Utilities.VisualTreeHelpers.FindVisualChildren<T>(System.Windows.DependencyObject, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable(Of T)

### Remarks

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.GetItemAtLocation(System.Windows.FrameworkElement,System.Windows.Point)'></a>

## VisualTreeHelpers.GetItemAtLocation(FrameworkElement, Point) Method

Helper para obter um objeto qualquer em uma dada posição da tela.

```csharp
public static object GetItemAtLocation(System.Windows.FrameworkElement parent, System.Windows.Point pt);
```
#### Parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.GetItemAtLocation(System.Windows.FrameworkElement,System.Windows.Point).parent'></a>

`parent` [System.Windows.FrameworkElement](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.FrameworkElement 'System.Windows.FrameworkElement')

O elemento-base para início da análise

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.GetItemAtLocation(System.Windows.FrameworkElement,System.Windows.Point).pt'></a>

`pt` [System.Windows.Point](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Point 'System.Windows.Point')

A coordenada horizontal x vertical para análise

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

### Remarks

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.IsVisualChildOf(System.Windows.DependencyObject,System.Windows.DependencyObject)'></a>

## VisualTreeHelpers.IsVisualChildOf(DependencyObject, DependencyObject) Method

Helper para detectar se uma instância é descendente no Visu de outra instância desejada

```csharp
public static bool IsVisualChildOf(System.Windows.DependencyObject current, System.Windows.DependencyObject parent);
```
#### Parameters

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.IsVisualChildOf(System.Windows.DependencyObject,System.Windows.DependencyObject).current'></a>

`current` [System.Windows.DependencyObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyObject 'System.Windows.DependencyObject')

<a name='EficazFramework.XAML.Utilities.VisualTreeHelpers.IsVisualChildOf(System.Windows.DependencyObject,System.Windows.DependencyObject).parent'></a>

`parent` [System.Windows.DependencyObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyObject 'System.Windows.DependencyObject')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')