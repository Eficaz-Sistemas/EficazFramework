using System.Runtime.CompilerServices;

namespace Blazor.APIs;

internal static class Vendor
{
    internal static WebApplication MapVendors(this WebApplication app)
    {
        app.MapGet("/api/vendors", () => GetVendors()).AllowAnonymous();
        return app;
    }

    //TODO: Implement Unit of Work, Repositories, etc

    private static IEnumerable<Entities.Vendor>? _cacheVendors;
    internal static IEnumerable<Entities.Vendor> GetVendors()
    {
        _cacheVendors ??= [
                new Entities.Vendor()
                {
                    Id = Guid.NewGuid(),
                    Name = "John Moreno"
                },
                new Entities.Vendor()
                {
                    Id = Guid.NewGuid(),
                    Name = "Brian Lawson"
                }
            ];
        return _cacheVendors!;
    }
}
