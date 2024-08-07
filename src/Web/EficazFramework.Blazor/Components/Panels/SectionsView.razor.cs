﻿using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Components;
public partial class SectionsView : MudBlazor.MudComponentBase
{
    private bool _isOpen = false;
    [Parameter]
    public bool IsOpen
    {
        get => _isOpen;
        set
        {
            _isOpen = value;
        }
    }

    [Parameter] public string Icon { get; set; } = MudBlazor.Icons.Material.Outlined.ViewCarousel;

    [Parameter] public int Elevation { get; set; } = 8;

    [Parameter] public string Tooltip { get; set; } = Resources.Strings.Components.MDIContainer_Sections;

    [Parameter] public MudBlazor.Origin AnchorOrigin { get; set; } = MudBlazor.Origin.TopLeft;

    [Parameter] public MudBlazor.Origin TransformOrigin { get; set; } = MudBlazor.Origin.BottomLeft;


    /// <summary>
    /// The template for Current Section representation
    /// </summary>
    [Parameter] public RenderFragment CurrentSectionTemplate { get; set; }


    private long _currentSection = 0;
    /// <summary>
    /// Current MDI Section (for multi tenant purposes)
    /// </summary>
    [Parameter]
    public long CurrentSection
    {
        get => _currentSection;
        set
        {
            if (_currentSection == value) return;
            _currentSection = value;
            InvokeAsync(async () => await SectionChanged.InvokeAsync(value));
            
        }
    }
    [Parameter] public EventCallback<long> SectionChanged { get; set; }

    /// <summary>
    /// Source for Available Sections (tenants)
    /// </summary>
    [Parameter] public IEnumerable<EficazFramework.Application.Section> ItemsSource { get; set; } = new List<EficazFramework.Application.Section>();


    /// <summary>
    /// Text for show into "New Section" button
    /// </summary>
    [Parameter] public string NewSectionText { get; set; } = Resources.Strings.Components.MDIContainer_NewSection;


    /// <summary>
    /// Action to invoke when "New Section" button is clicked
    /// </summary>
    [Parameter] public Action NewSectionClick { get; set; }


    /// <summary>
    /// Text for show into CloseAllSections" button
    /// </summary>
    [Parameter] public string CloseAllSectionsText { get; set; } = Resources.Strings.Components.MDIContainer_CloseAllSections;


    /// <summary>
    /// Action to invoke when "Clear" button is clicked
    /// </summary>
    [Parameter] public Action<long> CloseSectionClick { get; set; }


    /// <summary>
    /// Action to invoke when "Clear" button is clicked
    /// </summary>
    [Parameter] public Action CloseAllSectionsClick { get; set; }


    /// <summary>
    /// Gets or Sets if Host should create a new Section automatically when user click
    /// on 'New Section' button. Otherwise, the NewSectionClick action will be invoked
    /// for custom logic.
    /// </summary>
    [Parameter] public bool AutoManageSections { get; set; } = true;


    private void OnNewSectionClick()
    {
        if (AutoManageSections)
            AddSection();
        else
            NewSectionClick?.Invoke();
    }

    private void AddSection()
    {
        long id = ItemsSource.DefaultIfEmpty(new(0)).Max(s => s.ID) + 1;
        (ItemsSource as IList<EficazFramework.Application.Section>)?.Add(new EficazFramework.Application.Section(id)
        {
            Name = $"Section {id}"
        });
        CurrentSection= id;
    }

    private void UpdateCurrentSection(long id)
    {
        CurrentSection = id;
        StateHasChanged();
    }

    private void RemoveSection(EficazFramework.Application.Section section)
    {
        long id = section.ID;
        if (AutoManageSections)
        {
            (ItemsSource as IList<EficazFramework.Application.Section>)?.Remove(section);
            CurrentSection = ItemsSource.LastOrDefault()?.ID ?? 0;
        }
        else
            CloseSectionClick?.Invoke(id);
    }

    private void OnCloseAllSectionsClick()
    {
        if (AutoManageSections)
            (ItemsSource as IList<EficazFramework.Application.Section>)?.Clear();
        else
            CloseAllSectionsClick?.Invoke();

        CurrentSection = 0;
    }



    /// <summary>
    /// Css builder for the Sections Button
    /// </summary>
    private string ToggleButtonClass() =>
            new CssBuilder()
                .AddClass("ef-mdi-buttons-toolbar")
                .AddClass("mud-elevation-0")
                .AddClass(Class)
                .Build();

    /// <summary>
    /// Style builder for the Sections Button
    /// </summary>
    private string ToggleButtonStyle() =>
            new StyleBuilder()
                .AddStyle("width", "unset;")
                .AddStyle("min-width", "48px;")
                .AddStyle(Style)
                .Build();

    /// <summary>
    /// Style builder for every section div
    /// </summary>
    protected string SectionItemStyle(long Id) =>
                new StyleBuilder()
                    .AddStyle("background-color", "var(--mud-palette-primary)", CurrentSection == Id)
                    .AddStyle("width", "200px")
                    .AddStyle("height", "125px")
                    .AddStyle("cursor", "pointer")
                    .Build();


    /// <summary>
    /// Toggle the Sections View into Opened/Closed states.
    /// </summary>
    /// <param name="onlyClose">Just act as closing the menu</param>
    public void ToggleOpen(bool onlyClose = false)
    {
        if (onlyClose)
            _isOpen = false;
        else
            _isOpen = !_isOpen;

        StateHasChanged();
    }

}
