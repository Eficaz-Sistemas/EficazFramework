using System;
using System.Collections.Generic;
using System.Text;

namespace EficazFramework.Configuration
{
    public class ApplicationManifest
    {
        public static RenderMode RenderMode { get; set; } = RenderMode.ServerPreRendered;
    }

    public enum RenderMode
    {
        Server = 0,
        ServerPreRendered = 1,
        Client = 2
    }
}
