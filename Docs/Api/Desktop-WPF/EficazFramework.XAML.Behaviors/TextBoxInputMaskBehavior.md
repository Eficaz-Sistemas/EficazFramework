#### [EficazFramework.WPF](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.XAML.Behaviors](EficazFrameworkData.md#EficazFramework.XAML.Behaviors 'EficazFramework.XAML.Behaviors')

## TextBoxInputMaskBehavior Class

InputMask for Textbox with 2 Properties: [EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior.InputMask](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior.InputMask 'EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior.InputMask'), [EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior.PromptChar](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior.PromptChar 'EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior.PromptChar').

```csharp
public class TextBoxInputMaskBehavior : Microsoft.Xaml.Behaviors.Behavior<System.Windows.Controls.TextBox>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Windows.Threading.DispatcherObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Threading.DispatcherObject 'System.Windows.Threading.DispatcherObject') &#129106; [System.Windows.DependencyObject](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DependencyObject 'System.Windows.DependencyObject') &#129106; [System.Windows.Freezable](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Freezable 'System.Windows.Freezable') &#129106; [System.Windows.Media.Animation.Animatable](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Media.Animation.Animatable 'System.Windows.Media.Animation.Animatable') &#129106; [Microsoft.Xaml.Behaviors.Behavior](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Xaml.Behaviors.Behavior 'Microsoft.Xaml.Behaviors.Behavior') &#129106; [Microsoft.Xaml.Behaviors.Behavior&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Xaml.Behaviors.Behavior-1 'Microsoft.Xaml.Behaviors.Behavior`1')[System.Windows.Controls.TextBox](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Controls.TextBox 'System.Windows.Controls.TextBox')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Xaml.Behaviors.Behavior-1 'Microsoft.Xaml.Behaviors.Behavior`1') &#129106; TextBoxInputMaskBehavior
### Methods

<a name='EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior.Pasting(object,System.Windows.DataObjectPastingEventArgs)'></a>

## TextBoxInputMaskBehavior.Pasting(object, DataObjectPastingEventArgs) Method

Pasting prüft ob korrekte Daten reingepastet werden

```csharp
private void Pasting(object sender, System.Windows.DataObjectPastingEventArgs e);
```
#### Parameters

<a name='EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior.Pasting(object,System.Windows.DataObjectPastingEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior.Pasting(object,System.Windows.DataObjectPastingEventArgs).e'></a>

`e` [System.Windows.DataObjectPastingEventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.DataObjectPastingEventArgs 'System.Windows.DataObjectPastingEventArgs')

<a name='EficazFramework.XAML.Behaviors.TextBoxInputMaskBehavior.TreatSelectedText()'></a>

## TextBoxInputMaskBehavior.TreatSelectedText() Method

Falls eine Textauswahl vorliegt wird diese entsprechend behandelt.

```csharp
private bool TreatSelectedText();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true Textauswahl behandelt wurde, ansonsten falls