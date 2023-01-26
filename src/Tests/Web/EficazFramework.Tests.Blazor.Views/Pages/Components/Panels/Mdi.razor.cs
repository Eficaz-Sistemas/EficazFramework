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
    private EficazFramework.Components.StartMenu? _startMenu;
    private EficazFramework.Components.SectionsView? _sectionsView;

    private void NewSection()
    {
        ApplicationManager!.SectionManager!.ActivateSection(new(((long)(ApplicationManager?.SectionManager.Sections.Count ?? 0)))
        {
            Name = $"Section {ApplicationManager!.SectionManager!.Sections.Count}",
            Icon = MudBlazor.Icons.Material.Filled.Inbox,
        }, true);
        StateHasChanged();
    }

    private void SectionChanged(long newID)
    {
        ApplicationManager!.SectionManager.CurrentSectionId = newID;
        //StateHasChanged();
    }

    private void CloseSection(long id)
    {
        ApplicationManager!.SectionManager!.DisposeSection(id);
        StateHasChanged();
    }

    private void CloseAllSections()
    {
        var ids = ApplicationManager!.SectionManager!.Sections.Select(s => s.ID).ToList();
        foreach(long id in ids)
        {
            ApplicationManager!.SectionManager!.DisposeSection(id);
        }
        StateHasChanged();
    }

    private void AppClick(EficazFramework.Application.ApplicationDefinition app)
    {
        _startMenu!.ToggleOpen(true);
        _mdi!.LoadApplication(app);
    }

}
