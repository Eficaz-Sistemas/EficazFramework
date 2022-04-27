#### [EficazFramework.WPF](EficazFrameworkWPF.md 'EficazFramework WPF')
### [EficazFramework.Utilities](EficazFrameworkWPF.md#EficazFramework.Utilities 'EficazFramework.Utilities').[DipHelper](EficazFramework.Utilities/DipHelper.md 'EficazFramework.Utilities.DipHelper')

## DipHelper.GetSystemDpiFactor() Method

Gets the system DPI scale factor (compared to 96 dpi).  
From http://blogs.msdn.com/jaimer/archive/2007/03/07/getting-system-dpi-in-wpf-app.aspx  
Should not be called before the Loaded event (else XamlException mat throw)

```csharp
private static System.Windows.Point GetSystemDpiFactor();
```

#### Returns
[System.Windows.Point](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Point 'System.Windows.Point')  
A Point object containing the X- and Y- scale factor.