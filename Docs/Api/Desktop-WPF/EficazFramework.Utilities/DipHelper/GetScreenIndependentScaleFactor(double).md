#### [EficazFramework.WPF](EficazFramework WPF.md 'EficazFramework WPF')
### [EficazFramework.Utilities](EficazFramework WPF.md#EficazFramework.Utilities 'EficazFramework.Utilities').[DipHelper](EficazFramework.Utilities/DipHelper.md 'EficazFramework.Utilities.DipHelper')

## DipHelper.GetScreenIndependentScaleFactor(double) Method

Gets the scale factor to apply to a WPF application  
so that 96 DIP always equals 1 inch on the screen (whatever the system DPI).

```csharp
public static System.Windows.Point GetScreenIndependentScaleFactor(double diagonalScreenSize);
```
#### Parameters

<a name='EficazFramework.Utilities.DipHelper.GetScreenIndependentScaleFactor(double).diagonalScreenSize'></a>

`diagonalScreenSize` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

Size - in inch - of the diagonal of the screen

#### Returns
[System.Windows.Point](https://docs.microsoft.com/en-us/dotnet/api/System.Windows.Point 'System.Windows.Point')  
A Point object containing the X- and Y- scale factor.