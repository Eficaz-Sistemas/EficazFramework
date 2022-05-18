using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using EficazFramework.Application;

namespace EficazFramework.Components;
public partial class MdiHost : MudBlazor.MudBaseItemsControl<MdiWindow>
{
    [Inject] public EficazFramework.Application.IApplicationManager ApplicationManager { get; set; }

    protected string Classname =>
                new CssBuilder()
                    .AddClass(Class)
                    .AddClass("d-flex")
                    .AddClass("flex-grow-1")
                    .AddClass("ef-mdi-host")
                    .Build();

    protected string StyleName =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .Build();

    public override void AddItem(MdiWindow item)
    {
        if (!Items.Contains(item))
            Items.Add(item);
    }

    private IEnumerable<ApplicationInstance> RunningApplications() =>
        ApplicationManager.RunningApplications.Where(app => app.SessionID == 0 | app.SessionID == ApplicationManager.SectionManager.CurrentSection.ID).ToList();
    
}
