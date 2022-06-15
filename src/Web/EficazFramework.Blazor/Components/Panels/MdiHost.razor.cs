using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using EficazFramework.Application;

namespace EficazFramework.Components;
public partial class MdiHost : MudBlazor.MudBaseBindableItemsControl<MdiWindow, ApplicationInstance>
{
    [Inject] public EficazFramework.Application.IApplicationManager? ApplicationManager { get; set; }

    [Parameter] public long CurrentSection { get; set; } = 0;

    protected string Classname =>
                new CssBuilder()
                    .AddClass(Class)
                    .AddClass("d-flex flex-column")
                    .AddClass("flex-grow-1")
                    .AddClass("ef-mdi-host")
                    .Build();

    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .Build();

    private string TaskBarButtonStyle(MdiWindow item) =>
                new StyleBuilder()
                    .AddStyle("padding", "8px")
                    .AddStyle("padding-left", "12px")
                    .AddStyle("padding-right", "12px")
                    .AddStyle("border-radius", "0px")
                    .AddStyle("border-top", "solid 3px transparent")
                    .AddStyle("border-bottom", "solid 3px transparent")
                    .AddStyle("border-top", "solid 3px var(--mud-palette-primary)", SelectedContainer == item)
                    .Build();

    public override void AddItem(MdiWindow item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            MoveTo(Items.IndexOf(item));
        }
    }

    private IEnumerable<ApplicationInstance> RunningApplications() =>
        ItemsSource.Where(app => app.SessionID == 0 || app.SessionID == CurrentSection).ToList();

    public void LoadApplication(ApplicationDefinition app)
    {
        if (ApplicationManager != null)
        {
            if (app.IsPublic == false && ApplicationManager.SectionManager.CurrentSection.ID == 0)
                return;

            var appInstance = ApplicationManager!.Activate(app);
            var container = Items.SingleOrDefault(ct => object.ReferenceEquals(ct.ApplicationInstance, appInstance));
            if (container != null)
                MoveTo(Items.IndexOf(container));
        }
    }

}
