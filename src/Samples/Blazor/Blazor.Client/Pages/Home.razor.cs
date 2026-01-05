using EficazFramework.Resources.Strings;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Blazor.Client.Pages;

public partial class Home
{
    [Inject] EficazFramework.Application.IApplicationManager? ApplicationManager { get; set; }


    private EficazFramework.Components.MdiHost? _mdiHost;
    private EficazFramework.Components.StartMenu? _startMenu;

    private IEnumerable<EficazFramework.Application.IApplicationDefinition> _mainApps = [];
    private IEnumerable<EficazFramework.Application.IApplicationDefinition> _uiApps = [];

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _mainApps = Apps.Mapping.MapApplications();

            if (!(_startMenu?.IsOpen ?? true))
                _startMenu?.ToggleOpen();
        }

        return base.OnAfterRenderAsync(firstRender);
    }

    
    private void AppClick(EficazFramework.Application.ApplicationDefinition app)
    {
        _startMenu!.ToggleOpen(true);

        if (!app.IsPublic && ApplicationManager!.SectionManager.CurrentSectionId == 0)
        {
            // wait to sync MdiHost.CurrentSectionId and ApplicationManager!.SectionManager.CurrentSectionId by @bind
            NewSection();
            _appToOpenOnSectionChanged = app;
            return;
        }

        _mdiHost!.LoadApplication(app);
    }

    // SECTION MANAGER:

    private EficazFramework.Components.SectionsView? _sectionsView;

    /// <summary>
    /// Acionado pelo botão + (adicionar seção) na barra de tarefas.
    /// </summary>
    private async void NewSection()
    {
        var max = ApplicationManager!.SectionManager!.Sections.DefaultIfEmpty().Select(s => s?.ID ?? 0).Max();
        EficazFramework.Application.Section section = new(max + 1)
        {
            Name = $"Section {max + 1}",
        };
        ApplicationManager!.SectionManager!.ActivateSection(section, true);
        StateHasChanged();
    }

    EficazFramework.Application.ApplicationDefinition? _appToOpenOnSectionChanged;
    /// <summary>
    /// Disparado ao trocar a seção ativa
    /// </summary>
    private void SectionChanged(long newID)
    {
        ApplicationManager!.SectionManager.CurrentSectionId = newID;
        StateHasChanged();

        if (_appToOpenOnSectionChanged is not null)
            _mdiHost!.LoadApplication(_appToOpenOnSectionChanged);

        _appToOpenOnSectionChanged = null;
    }


    /// <summary>
    /// Solicita o dispose de uma seção ativa
    /// </summary>
    /// <param name="id"></param>
    private void CloseSection(long id)
    {
        ApplicationManager!.SectionManager!.DisposeSection(id);
        StateHasChanged();
    }


    /// <summary>
    /// Solicita o dispose de todas as seções ativas
    /// </summary>
    private void CloseAllSections()
    {
        var ids = ApplicationManager!.SectionManager!.Sections.Select(s => s.ID).ToList();
        foreach (long id in ids)
        {
            ApplicationManager!.SectionManager!.DisposeSection(id);
        }
        StateHasChanged();
    }

}