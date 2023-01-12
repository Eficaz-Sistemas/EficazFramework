using Microsoft.AspNetCore.Components;

namespace EficazFramework.Tests.Blazor.Views.Pages.Components.Panels;

public partial class Mdi
{
    [Inject] public EficazFramework.Application.IApplicationManager? ApplicationManager { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        EficazFramework.Tests.Blazor.Views.Resources.Mocks.Applications.GenerateApps(ApplicationManager);
    }

    private EficazFramework.Components.MdiHost? _mdi;

    private void NewSection()
    {
        ApplicationManager?.SectionManager.ActivateSection(new(((long)(ApplicationManager?.SectionManager.Sections.Count ?? 0)) + 1)
        {
            Name = $"Section {ApplicationManager?.SectionManager.Sections.Count + 1}",
            Icon = MudBlazor.Icons.Material.Filled.Inbox,
        }, true);
    }

}
