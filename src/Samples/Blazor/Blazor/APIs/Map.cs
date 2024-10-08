﻿namespace Blazor.APIs;

public static class Mappings
{
    internal static WebApplication MapApis(this WebApplication app)
    {
        app.MapVendors();
        app.MapProducts();
        app.MapCustomers();
        return app;
    }

}
