﻿namespace EficazFramework.Application;

public static class ApplicationDefinitionHelpers
{
    public static WpfApplicationTarget Wpf([NotNull] this ApplicationDefinition applicationDefinition) =>
        (WpfApplicationTarget)applicationDefinition.Targets["WPF"];


}


/// <summary>
/// Wrapper class for <see cref="EficazFramework.Application.ApplicationTarget.Properties"/> parameters for Blazor target.
/// </summary>
public sealed class WpfApplicationTarget : ApplicationTarget
{
    public WindowState StartWindowState
    {
        get
        {
            if (!Properties.ContainsKey("StartWindowState"))
                Properties["StartWindowState"] = WindowState.Normal;
            return (WindowState)Properties["StartWindowState"];
        }
        set => Properties["StartWindowState"] = value;
    }

    //public bool Resizable
    //{
    //    get
    //    {
    //        if (!Properties.ContainsKey("Resizable"))
    //            Properties["Resizable"] = true;
    //        return (bool)Properties["Resizable"];
    //    }
    //    set => Properties["Resizable"] = value;
    //}


    public int OffsetX
    {
        get 
        {
            if (!Properties.ContainsKey("OffsetX"))
                Properties["OffsetX"] = 15;
            return (int)Properties["OffsetX"];
        }
            
        set => Properties["OffsetX"] = value;
    }

    public int OffsetY
    {
        get
        {
            if (!Properties.ContainsKey("OffsetY"))
                Properties["OffsetY"] = 15;
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
