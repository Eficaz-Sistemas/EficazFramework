using Microsoft.AspNetCore.Components;

namespace Blazor.Client.Pages;

public partial class Tenant
{
    [CascadingParameter] EficazFramework.Components.MdiWindow? MdiWindow { get; set; }

}
