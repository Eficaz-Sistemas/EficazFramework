﻿namespace Blazor.APIs;

public static class Mappings
{
    internal static WebApplication MapApis(this WebApplication app)
    {
        app.MapVendors();
        return app;
    }

}
