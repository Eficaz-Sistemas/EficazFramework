using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Blazor.APIs;

internal static class Vendor
{
    internal static WebApplication MapVendors(this WebApplication app)
    {
        var vendors = app.MapGroup("/api/vendors");
        vendors.MapGet("", () => TypedResults.Ok(GetVendors()));
        vendors.MapGet("/{search}", (string search) => TypedResults.Ok(SearchVendors(search)));
        vendors.MapPost("", ([FromBody] VendorDto vendor) => AddVendor(vendor));
        vendors.MapPut("", ([FromBody] VendorDto vendor) => UpdateVendor(vendor));
        vendors.MapDelete("/{vendorID}", (string vendorID) => DeleteVendor(Guid.Parse(vendorID)));
        vendors.AllowAnonymous();

        return app;
    }

    //TODO: Implement Unit of Work, Repositories, etc

    private static List<Entities.Vendor>? _cacheVendors;
    private static List<Entities.Vendor> GetVendors()
    {
        var faker = new Bogus.Faker<Entities.Vendor>();
        faker
            .RuleFor(v => v.Id, r => r.Random.Uuid())
            .RuleFor(v => v.Name, r => r.Person.FullName);

        _cacheVendors ??= faker.Generate(50);
        return _cacheVendors!;
    }

    private static List<Entities.Vendor> SearchVendors(string search) =>
        GetVendors().Where(v => v.Name!.Contains(search, StringComparison.InvariantCultureIgnoreCase)).ToList();

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

    private static IResult UpdateVendor(VendorDto vendor)
    {
        if (vendor == null)
            return TypedResults.UnprocessableEntity();

        try
        {
            // PK check
            var vendorEntity = GetVendors().FirstOrDefault(v => v.Id == vendor.Id);
            if (vendorEntity is null)
                return TypedResults.UnprocessableEntity(new[] { $"Any vendor were found with ID {vendor.Id}." });

            // Validation
            var result = (vendor as Shared.Interfaces.IValidatable).Validate();
            if (result?.Any() ?? false)
                return TypedResults.UnprocessableEntity(result);

            // Mapper work
            vendorEntity.Name = vendor.Name;
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.ToString());
        }

        return TypedResults.Ok(vendor);
    }

    private static IResult DeleteVendor(Guid vendorID)
    {
        try
        {
            // PK check
            var vendorEntity = GetVendors().FirstOrDefault(v => v.Id == vendorID);
            if (vendorEntity is null)
                return TypedResults.UnprocessableEntity(new[] { $"Any vendor were found with ID {vendorID}." });


            // Mapper work
            _ = (_cacheVendors?.Remove(vendorEntity));
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.ToString());
        }

        return TypedResults.Ok(vendorID);
    }

}
