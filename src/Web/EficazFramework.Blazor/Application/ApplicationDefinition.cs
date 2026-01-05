using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Application;

public static class ApplicationDefinitionHelpers
{
    public static BlazorApplicationTarget? Blazor([NotNull] this IApplicationDefinition applicationDefinition) =>
        (BlazorApplicationTarget)applicationDefinition.Targets["Blazor"];


}


/// <summary>
/// Wrapper class for <see cref="EficazFramework.Application.ApplicationTarget.Properties"/> parameters for Blazor target.
/// </summary>
public sealed class BlazorApplicationTarget : ApplicationTarget
{
    public bool IsMaximized
    {
        get
        {
            if (!Properties.ContainsKey("IsMaximized"))
                Properties["IsMaximized"] = false;
            return (bool)Properties["IsMaximized"];
        }
        set => Properties["IsMaximized"] = value;
    }

    public bool Resizable
    {
        get
        {
            if (!Properties.ContainsKey("Resizable"))
                Properties["Resizable"] = true;
            return (bool)Properties["Resizable"];
        }
        set => Properties["Resizable"] = value;
    }


    public int OffsetX
    {
        get 
        {
            if (!Properties.ContainsKey("OffsetX"))
                Properties["OffsetX"] = 50;
            return (int)Properties["OffsetX"];
        }
            
        set => Properties["OffsetX"] = value;
    }

    public int OffsetY
    {
        get
        {
            if (!Properties.ContainsKey("OffsetY"))
                Properties["OffsetY"] = 50;
            return (int)Properties["OffsetY"];
        }
        set => Properties["OffsetY"] = value;
    }


    public int Width
    {
        get
        {
            if (!Properties.ContainsKey("Width"))
                Properties["Width"] = 425;
            return (int)Properties["Width"];
        }
        set => Properties["Width"] = value;
    }

    public int Height
    {
        get
        {
            if (!Properties.ContainsKey("Height"))
                Properties["Height"] = 200;
            return (int)Properties["Height"];
        }
        set => Properties["Height"] = value;
    }


    public int ZIndex
    {
        get
        {
            if (!Properties.ContainsKey("ZIndex"))
                Properties["ZIndex"] = 1;
            return (int)Properties["ZIndex"];
        }
        internal set => Properties["ZIndex"] = value;
    }


}
