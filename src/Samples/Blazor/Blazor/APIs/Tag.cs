using EficazFramework.Extensions;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Blazor.APIs;

internal static class Tag
{
    internal static WebApplication MapTags(this WebApplication app)
    {
        var tags = app.MapGroup("/api/tags");
        tags.MapGet("", () => TypedResults.Ok(GetTags()));
        //tags.MapGet("/{search}", (string search) => TypedResults.Ok(SearchTags(search)));
        //tags.MapPost("", ([FromBody] TagDto tag) => AddTag(tag));
        //tags.MapPut("", ([FromBody] TagDto tag) => UpdateTag(tag));
        //tags.MapDelete("/{tagID}", (string tagID) => DeleteTag(Guid.Parse(tagID)));
        tags.RequireAuthorization();
        return app;
    }

    private static List<Entities.Tag>? _cacheTags;
    private static List<Entities.Tag> GetTags()
    {
        var faker = new Bogus.Faker<Entities.Tag>();
        faker
            .RuleFor(p => p.Id, r => r.Commerce.Ean8())
            .RuleFor(p => p.Name, r => r.Commerce.Product());

        _cacheTags ??= faker.Generate(12);
        return _cacheTags!;
    }


}
