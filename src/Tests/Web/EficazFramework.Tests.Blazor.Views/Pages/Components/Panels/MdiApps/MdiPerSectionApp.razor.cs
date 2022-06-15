using EficazFramework.Application;
using Microsoft.AspNetCore.Components;

namespace EficazFramework.Tests.Blazor.Views.Pages.Components.Panels.MdiApps;

public partial class MdiPerSectionApp
{
    [CascadingParameter] public ApplicationInstance? ApplicationInstance { get; set; }
}
