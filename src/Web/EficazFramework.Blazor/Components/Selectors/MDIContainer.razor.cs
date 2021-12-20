using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Components;

public partial class MDIContainer
{
    private MudBlazor.MudTabs tabsmanager;
    private string idtorender;

    [Parameter] public RenderFragment Index { get; set; }
    [Parameter] public int Elevation { get; set; }
    [Parameter] public string Class { get; set; }

    [Parameter] public bool ScrollX { get; set; } = true;
    [Parameter] public bool ScrollY { get; set; } = true;

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (!string.IsNullOrEmpty(idtorender))
        {
            var appsRunning = GetRunningApplications().ToList();
            var instance = appsRunning.Where(app => GetTabID(app) == idtorender).FirstOrDefault();
            if (instance != null)
                tabsmanager.ActivatePanel(appsRunning.IndexOf(instance) + 1);

            idtorender = null;
            StateHasChanged();
        }
        return base.OnAfterRenderAsync(firstRender);
    }

    protected IEnumerable<EficazFramework.Application.ApplicationInstance> GetRunningApplications()
    {

        return Application.ApplicationManager.Instance.RunningAplications.Where((e) =>
                {
                    Application.ApplicationInstance app = e as Application.ApplicationInstance;
                    return (app.SessionID == 0 || app.SessionID == Application.ApplicationManager.Instance?.SectionManager.CurrentSection?.ID);
                }).ToList();
    }

    protected string GetTabID(EficazFramework.Application.ApplicationInstance app)
    {
        return $"sc:{(app.IsPublic ? 0 : Application.ApplicationManager.Instance.SectionManager.CurrentSection.ID)}|app:{app.TooltipTilte}";
    }


    protected RenderFragment RenderApplicationMetadata(EficazFramework.Application.ApplicationDefinition app)
    {
        var appmetadata = app.Attributes.Where((a) => a.Key == $"Blazor:{EficazFramework.Application.ApplicationDefinitions.COMPONENTTYPE}").FirstOrDefault();
        if (appmetadata == null)
            return null;
        var target = appmetadata.Value;
        if (target.GetType() == typeof(string))
            target = Type.GetType((string)target);

        var appref = app.Attributes.Where((a) => a.Key == $"Blazor:{EficazFramework.Application.ApplicationDefinitions.APPINSTANCE}").FirstOrDefault();
        return new RenderFragment(builder =>
        {
            builder.OpenComponent(0, (Type)target);
            builder.AddComponentReferenceCapture(1, (__value) => { appref.Value = __value; });
            builder.CloseComponent();
        });
    }

    private string ResolvedIcon(EficazFramework.Application.ApplicationDefinition app)
    {
        if (app == null)
            return "";

        string resolved = (string)(app.Attributes.Where((e) => e.Key == $"Blazor:{EficazFramework.Application.ApplicationDefinitions.ICON}").FirstOrDefault()?.Value ?? "");
        if (string.IsNullOrEmpty(resolved))
            resolved = (string)(app.Icon ?? "");

        return resolved;
    }

    public void Activate(EficazFramework.Application.ApplicationDefinition app)
    {
        if (app == null)
        {
            tabsmanager.ActivatePanel(0);
            return;
        }

        idtorender = $"sc:{(app.IsPublic ? 0 : Application.ApplicationManager.Instance.SectionManager.CurrentSection.ID)}|app:{app.TooltipTilte}";
        Application.ApplicationManager.Instance.Activate(app);
        StateHasChanged();
    }

    public void CloseApp(EficazFramework.Application.ApplicationInstance app)
    {
        var appsRunning = GetRunningApplications().ToList();
        var instance = appsRunning.Where(item => GetTabID(app) == GetTabID(item)).FirstOrDefault();
        if (instance != null)
        {

            Application.ApplicationManager.Instance.RunningAplications.Remove(app);
            idtorender = null;
            StateHasChanged();
        }
    }

    private string StyleBuilder()
    {
        return $"overflow-y:{(ScrollY ? "auto" : "hidden")};overflow-x:{(ScrollX ? "auto" : "hidden")};";
    }
}
