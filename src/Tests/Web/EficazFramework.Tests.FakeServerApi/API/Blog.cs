﻿using Bogus;
using System.Linq;
using System.Reflection.Metadata;

namespace EficazFramework.API;

internal static class Blog
{
    public static readonly IEnumerable<Resources.Mocks.Classes.BlogEntity> BlogDb;
    
    static Blog()
    {
        var faker = new Faker<Resources.Mocks.Classes.BlogEntity>("pt_BR")
            .RuleFor(o => o.Name, f => f.Company.CompanyName());

        List<Resources.Mocks.Classes.BlogEntity> result = new();
        for (int i = 0; i < 5; i++)
        {
            result.Add(faker.Generate());
        }
        BlogDb = result;
    }

    internal static IResult Get(EficazFramework.Expressions.QueryDescription parameters)
    {
        if (parameters?.Filter is null)
            return Results.Ok(BlogDb);

        var result = BlogDb.Where(Expressions.ExpressionObjectQuery.GetExpression<Resources.Mocks.Classes.BlogEntity>(parameters.Filter).Compile()).ToList();
        return Results.Ok(result);
    }

    internal static IResult Update(Resources.Mocks.Classes.BlogEntity item)
    {
        var source = BlogDb.Where(i => i.Id == item.Id).FirstOrDefault();

        if (source == null)
            return Results.NotFound(item);

        source.Name = item.Name;
        return Results.Ok(source);
    }

    internal static IResult Insert(Resources.Mocks.Classes.BlogEntity item)
    {
        try
        {
            (BlogDb as IList<Resources.Mocks.Classes.BlogEntity>)!.Add(item);
            return Results.Ok(item);
        }
        catch
        {
            return Results.BadRequest();
        }
    }

    internal static IResult Delete(Resources.Mocks.Classes.BlogEntity item)
    {
        try
        {
            (BlogDb as IList<Resources.Mocks.Classes.BlogEntity>)!.Remove(item);
            return Results.Ok(item);
        }
        catch
        {
            return Results.BadRequest();
        }
    }

}
