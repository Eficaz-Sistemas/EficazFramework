﻿using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using EficazFramework.Application;
using Microsoft.JSInterop;

namespace EficazFramework.Components;
public partial class MdiHost : MudBlazor.MudBaseBindableItemsControl<MdiWindow, ApplicationInstance>
{
    /// <summary>
    /// IApplicationManager service instance, if available on DI
    /// </summary>
    [Inject] public EficazFramework.Application.IApplicationManager? ApplicationManager { get; set; }


    [Inject] IJSRuntime JsRutinme { get; set; }


    /// <summary>
    /// Breakpoint that defines the view on Frames (windows) or Full Screen
    /// </summary>
    [Parameter] public MudBlazor.Breakpoint Breakpoint { get; set; } = MudBlazor.Breakpoint.Xs;

    #region Parameters: Sections

    /// <summary>
    /// Current MDI Section (for multi tenant purposes)
    /// </summary>
    [Parameter] public long CurrentSection { get; set; } = 0;

    /// <summary>
    /// Gets or Sets if Host should create a new Section automatically when user click
    /// on 'New Section' button. Otherwise, the NewSectionClick action will be invoked
    /// for custom logic.
    /// </summary>
    [Parameter] public bool AutoManageSections { get; set; } = true;

    /// <summary>
    /// Source for Available Sections (tenants)
    /// </summary>
    [Parameter] public IEnumerable<EficazFramework.Application.Section> SectionsSource { get; set; } = new List<EficazFramework.Application.Section>();

    /// <summary>
    /// Text for show into "New Section" button
    /// </summary>
    [Parameter] public string NewSectionText { get; set; } = Resources.Strings.Components.MDIContainer_NewSection;

    /// <summary>
    /// Action to invoke when "New Section" button is clicked
    /// </summary>
    [Parameter] public Action NewSectionClick { get; set; }

    /// <summary>
    /// Gets and Sets the Section Menu and Button visibility. <br/>
    /// </summary>
    [Parameter] public bool ShowSectionsArea { get; set; } = true;

    #endregion


    #region Classes And Styles

    /// <summary>
    /// Css classes for main div element
    /// </summary>
    protected string Classname =>
                new CssBuilder()
                    .AddClass(Class)
                    .AddClass("d-flex flex-column")
                    .AddClass("flex-grow-1")
                    .AddClass("ef-mdi-host")
                    .Build();

    /// <summary>
    /// Styles for main div element
    /// </summary>
    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .Build();


    /// <summary>
    /// Style builder for the TaskBar Applications' Tiles
    /// </summary>
    private string TaskBarAppInstanceButtonStyle(ApplicationInstance item) =>
                new StyleBuilder()
                    .AddStyle("border-top", "solid 3px transparent")
                    .AddStyle("border-bottom", "solid 3px var(--mud-palette-primary)", object.ReferenceEquals(SelectedApp, item))
                    .AddStyle("border-radius", "3px")
                    .Build();

    /// <summary>
    /// Style builder for every section div
    /// </summary>
    protected string SectionStyleName(long Id) =>
                new StyleBuilder()
                    .AddStyle("background-color", "var(--mud-palette-primary)", CurrentSection == Id)
                    .AddStyle("width", "200px")
                    .AddStyle("height", "125px")
                    .Build();

    #endregion


   
    
    #region Section Area

    /// <summary>
    /// The template for Current Section representation on StartMenu's right
    /// </summary>
    [Parameter] public RenderFragment CurrentSectionTemplate { get; set; }


    private bool _sectionsMenuIsOpen = false;
    public bool SectionsMenuIsOpen => _sectionsMenuIsOpen;

    /// <summary>
    /// Toggle the Sections Menu on Open and Closed states.
    /// </summary>
    /// <param name="onlyClose">Just act as closing the menu</param>
    public void ToggleSectionsMenuOpen(bool onlyClose = false)
    {

        if (onlyClose)
            _sectionsMenuIsOpen = false;
        else
        {
            _sectionsMenuIsOpen = !_sectionsMenuIsOpen;
        }

        StateHasChanged();
    }

    /// <summary>
    /// Altera a seção ativa para o ID informado.
    /// </summary>
    /// <param name="id"></param>
    public void ActivateSection(long id)
    {
        CurrentSection = id;
        ApplicationManager?.SectionManager.ActivateSection(id);
        ToggleSectionsMenuOpen(true);
    }

    #endregion



    #region Applications

    public ApplicationInstance? SelectedApp { get; internal set; } = null;

    /// <summary>
    /// Add a new MdiWindow to the Host
    /// </summary>
    public override void AddItem(MdiWindow item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            MoveTo(Items.IndexOf(item));
            item.zIndex = Items.Count + 1;
        }
    }


    /// <summary>
    /// Running applications (MdiWindow) for the Current Section (ou public apps_
    /// </summary>
    private IEnumerable<ApplicationInstance> RunningApplications() =>
        ItemsSource.Where(app => app.SessionID == 0 || app.SessionID == CurrentSection).ToList();

    /// <summary>
    /// Start a new application instance (from <paramref name="app"/> metadata) and adds it to the host.
    /// </summary>
    public void LoadApplication(ApplicationDefinition app)
    {
        if (app.IsPublic == false && CurrentSection == 0)
            return;

        ApplicationInstance? newinstance;
        
        if (ApplicationManager != null)
        {
            newinstance = ApplicationManager!.Activate(app);
        }
        else
        {
            newinstance = ApplicationInstance.Create(app, CurrentSection);
            
            if (ItemsSource == null)
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
                Items.Add(new MdiWindow() { ApplicationInstance = newinstance });
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
            else
                (ItemsSource as IList<ApplicationInstance>)!.Add(newinstance);
        }

        if (!newinstance.Targets["Blazor"].Properties.ContainsKey("IsMaximized"))
            newinstance.Targets["Blazor"].Properties.Add("IsMaximized", false);

        if (!newinstance.Targets["Blazor"].Properties.ContainsKey("Position"))
            newinstance.Targets["Blazor"].Properties.Add("Position", new System.Drawing.Size(15, 15));

        if (!newinstance.Targets["Blazor"].Properties.ContainsKey("Size"))
            newinstance.Targets["Blazor"].Properties.Add("Size", new System.Drawing.Size(425, 250));

        SelectedApp = newinstance;

        var container = Items.SingleOrDefault(ct => object.ReferenceEquals(ct.ApplicationInstance, newinstance));
        container?.MoveToMe();

        StateHasChanged();
    }

    /// <summary>
    /// Closes the application from the <paramref name="appHost"/> parameter.
    /// </summary>
    public void CloseApplication(MdiWindow appHost)
    {      
        if (ItemsSource == null)
            Items.Remove(appHost);
        else
        {
            (ItemsSource as IList<ApplicationInstance>)!.Remove(appHost.ApplicationInstance);
            StateHasChanged();
        }

        foreach (var service in appHost.ApplicationInstance.Services)
            (service.Value as IDisposable)!.Dispose();

        var resultingItems = Items.Where(item => !object.ReferenceEquals(item, appHost)).ToList();

        if (resultingItems.Count > 0)
            SelectedApp = resultingItems.LastOrDefault()!.ApplicationInstance; ;

    }

    #endregion



    private void CloseMenus()
    {
        ToggleSectionsMenuOpen(true);
    }

}
