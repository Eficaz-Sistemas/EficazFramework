using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Blazor.APIs;

internal static class Vendor
{
    internal static WebApplication MapVendors(this WebApplication app)
    {
        app.MapGet("/api/vendors", () => TypedResults.Ok(GetVendors())).AllowAnonymous();
        app.MapPost("/api/vendors", ([FromBody] VendorDto vendor) => AddVendor(vendor)).AllowAnonymous();

        return app;
    }

    //TODO: Implement Unit of Work, Repositories, etc

    private static IList<Entities.Vendor>? _cacheVendors;
    private static IList<Entities.Vendor> GetVendors()
    {
        var faker = new Bogus.Faker<Entities.Vendor>();
        faker
            .RuleFor(v => v.Id, r => r.Random.Uuid())
            .RuleFor(v => v.Name, r => r.Person.FullName);

        _cacheVendors ??= faker.Generate(50);
        return _cacheVendors!;
    }

    private static IResult AddVendor(VendorDto vendor)
    {
        if (vendor == null)
            return TypedResults.UnprocessableEntity();

        try
        {
            // PK check

            if (GetVendors().Any(v => v.Id == vendor.Id))   
                return TypedResults.UnprocessableEntity(new[] { $"A vendor with ID {vendor.Id} already exists." } );

            // Validation
            var result = (vendor as Shared.Interfaces.IValidatable).Validate();
            if (result?.Any() ?? false)
                return TypedResults.UnprocessableEntity(result);

            // Mapper work
            Entities.Vendor newVendor = new()
            {
                Id = vendor.Id!.Value,
                Name = vendor.Name,
            };

            // Insert
            _cacheVendors!.Add(newVendor);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.ToString()); 
        }

        return TypedResults.Created($"/api/vendors/{vendor.Id}", vendor);
    }
}
