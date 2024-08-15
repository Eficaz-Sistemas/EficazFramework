using EficazFramework.Extensions;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Blazor.APIs;

internal static class Product
{
    internal static WebApplication MapProducts(this WebApplication app)
    {
        var products = app.MapGroup("/api/products");
        products.MapGet("", () => TypedResults.Ok(GetProducts()));
        products.MapGet("/{search}", (string search) => TypedResults.Ok(SearchProducts(search)));
        products.MapPost("", ([FromBody] ProductDto product) => AddProduct(product));
        products.MapPut("", ([FromBody] ProductDto product) => UpdateProduct(product));
        products.MapDelete("/{productID}", (string productID) => DeleteProduct(Guid.Parse(productID)));
        products.AllowAnonymous();

        return app;
    }

    //TODO: Implement Unit of Work, Repositories, etc

    private static List<Entities.Product>? _cacheProducts;
    private static List<Entities.Product> GetProducts()
    {
        var faker = new Bogus.Faker<Entities.Product>();
        faker
            .RuleFor(p => p.Id, r => r.Random.Uuid())
            .RuleFor(p => p.Name, r => r.Commerce.Product())
            .RuleFor(p => p.Price, r => Math.Round(r.Random.Decimal(0.01m, 15999.99m), 2));

        _cacheProducts ??= faker.Generate(1250);
        return _cacheProducts!;
    }

    private static List<Entities.Product> SearchProducts(string search) =>
        GetProducts().Where(v => v.Name!.Contains(search, StringComparison.InvariantCultureIgnoreCase)).ToList();

    private static IResult AddProduct(ProductDto product)
    {
        if (product == null)
            return TypedResults.UnprocessableEntity();

        try
        {
            // PK check

            if (GetProducts().Any(v => v.Id == product.Id))   
                return TypedResults.UnprocessableEntity(new[] { $"A product with ID {product.Id} already exists." } );

            // Validation
            var result = (product as Shared.Interfaces.IValidatable).Validate();
            if (result?.Any() ?? false)
                return TypedResults.UnprocessableEntity(result);

            // Mapper work
            Entities.Product newProduct = new()
            {
                Id = product.Id!,
                Name = product.Name,
                Price = product.Price
            };

            // Insert
            _cacheProducts!.Add(newProduct);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.ToString()); 
        }

        return TypedResults.Created($"/api/products/{product.Id}", product);
    }

    private static IResult UpdateProduct(ProductDto product)
    {
        if (product == null)
            return TypedResults.UnprocessableEntity();

        try
        {
            // PK check
            var productEntity = GetProducts().FirstOrDefault(v => v.Id == product.Id);
            if (productEntity is null)
                return TypedResults.UnprocessableEntity(new[] { $"Any product were found with ID {product.Id}." });

            // Validation
            var result = (product as Shared.Interfaces.IValidatable).Validate();
            if (result?.Any() ?? false)
                return TypedResults.UnprocessableEntity(result);

            // Mapper work
            productEntity.Name = product.Name;
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.ToString());
        }

        return TypedResults.Ok(product);
    }

    private static IResult DeleteProduct(Guid productID)
    {
        try
        {
            // PK check
            var productEntity = GetProducts().FirstOrDefault(v => v.Id == productID);
            if (productEntity is null)
                return TypedResults.UnprocessableEntity(new[] { $"Any product were found with ID {productID}." });


            // Mapper work
            _ = (_cacheProducts?.Remove(productEntity));
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(ex.ToString());
        }

        return TypedResults.Ok(productID);
    }

}
