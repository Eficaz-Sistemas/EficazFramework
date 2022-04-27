#### [EficazFramework.WPF](EficazFrameworkWPF.md 'EficazFramework WPF')
### [EficazFramework.Utilities](EficazFrameworkWPF.md#EficazFramework.Utilities 'EficazFramework.Utilities')

## DipHelper Class

A helper class for DIP (Device Independent Pixels) conversion and scaling operations.

```csharp
public sealed class DipHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DipHelper

| Fields | |
| :--- | :--- |
| [conv](EficazFramework.Utilities/DipHelper/conv.md 'EficazFramework.Utilities.DipHelper.conv') | |
| [DpiBase](EficazFramework.Utilities/DipHelper/DpiBase.md 'EficazFramework.Utilities.DipHelper.DpiBase') | |
| [tier](EficazFramework.Utilities/DipHelper/tier.md 'EficazFramework.Utilities.DipHelper.tier') | |

| Properties | |
| :--- | :--- |
| [FontSize_DataGridColumnText](EficazFramework.Utilities/DipHelper/FontSize_DataGridColumnText.md 'EficazFramework.Utilities.DipHelper.FontSize_DataGridColumnText') | |
| [FontSize_DefaultText](EficazFramework.Utilities/DipHelper/FontSize_DefaultText.md 'EficazFramework.Utilities.DipHelper.FontSize_DefaultText') | |
| [PrimaryScreenResolutionTier](EficazFramework.Utilities/DipHelper/PrimaryScreenResolutionTier.md 'EficazFramework.Utilities.DipHelper.PrimaryScreenResolutionTier') | |

| Methods | |
| :--- | :--- |
| [CmToDip(double)](EficazFramework.Utilities/DipHelper/CmToDip(double).md 'EficazFramework.Utilities.DipHelper.CmToDip(double)') | Converts centimeters to DIP (Device Independant Pixels). |
| [DipToCm(double)](EficazFramework.Utilities/DipHelper/DipToCm(double).md 'EficazFramework.Utilities.DipHelper.DipToCm(double)') | Converts DIP (Device Independant Pixels) to centimeters. |
| [DipToInch(double)](EficazFramework.Utilities/DipHelper/DipToInch(double).md 'EficazFramework.Utilities.DipHelper.DipToInch(double)') | Converts DIP (Device Independant Pixels) to inches. |
| [DipToMm(double)](EficazFramework.Utilities/DipHelper/DipToMm(double).md 'EficazFramework.Utilities.DipHelper.DipToMm(double)') | Converts DIP (Device Independant Pixels) to millimeters. |
| [DpiToScaleFactor(Point)](EficazFramework.Utilities/DipHelper/DpiToScaleFactor(Point).md 'EficazFramework.Utilities.DipHelper.DpiToScaleFactor(System.Windows.Point)') | Converts a DPI into a scale factor (compared to system DPI). |
| [GetPhysicalDpi(double)](EficazFramework.Utilities/DipHelper/GetPhysicalDpi(double).md 'EficazFramework.Utilities.DipHelper.GetPhysicalDpi(double)') | Gets the physical pixel density (DPI) of the screen. |
| [GetScreenIndependentScaleFactor(double)](EficazFramework.Utilities/DipHelper/GetScreenIndependentScaleFactor(double).md 'EficazFramework.Utilities.DipHelper.GetScreenIndependentScaleFactor(double)') | Gets the scale factor to apply to a WPF application<br/>so that 96 DIP always equals 1 inch on the screen (whatever the system DPI). |
| [GetSystemDpi()](EficazFramework.Utilities/DipHelper/GetSystemDpi().md 'EficazFramework.Utilities.DipHelper.GetSystemDpi()') | Gets the system configured DPI. |
| [GetSystemDpiFactor()](EficazFramework.Utilities/DipHelper/GetSystemDpiFactor().md 'EficazFramework.Utilities.DipHelper.GetSystemDpiFactor()') | Gets the system DPI scale factor (compared to 96 dpi).<br/>From http://blogs.msdn.com/jaimer/archive/2007/03/07/getting-system-dpi-in-wpf-app.aspx<br/>Should not be called before the Loaded event (else XamlException mat throw) |
| [InchToDip(double)](EficazFramework.Utilities/DipHelper/InchToDip(double).md 'EficazFramework.Utilities.DipHelper.InchToDip(double)') | Converts inches to DIP (Device Independant Pixels). |
| [MmToDip(double)](EficazFramework.Utilities/DipHelper/MmToDip(double).md 'EficazFramework.Utilities.DipHelper.MmToDip(double)') | Converts millimeters to DIP (Device Independant Pixels). |
| [PtToDip(double)](EficazFramework.Utilities/DipHelper/PtToDip(double).md 'EficazFramework.Utilities.DipHelper.PtToDip(double)') | Converts font points to DIP (Device Independant Pixels). |
