using Bogus;
using System.Linq;
using System.Reflection.Metadata;

namespace EficazFramework.API;

internal static class Blog
{
    private static readonly List<Resources.Mocks.Classes.BlogEntity> BlogDb = new();
    
    static Blog()
    {
        ResetDb();
    }

    public static void ResetDb()
    {
        var faker = new Faker<Resources.Mocks.Classes.BlogEntity>("pt_BR")
            .RuleFor(o => o.Id, f => f.Database.Random.Guid())
            .RuleFor(o => o.Name, f => f.Company.CompanyName());

        List<Resources.Mocks.Classes.BlogEntity> result = new();
        for (int i = 0; i < 5; i++)
        {
            result.Add(faker.Generate());
        }
        BlogDb.Clear();
        BlogDb.AddRange(result);
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
            BlogDb.Add(item);
            return Results.Ok(item);
        }
        catch
        {
            return Results.BadRequest();
        }
    }

    internal static IResult Delete(string itemId)
    {
        try
        {
            Resources.Mocks.Classes.BlogEntity item = BlogDb.Where(i => i.Id == Guid.Parse(itemId)).FirstOrDefault()!;
            BlogDb.Remove(item);
            return Results.Ok(item);
        }
        catch
        {
            return Results.BadRequest();
        }
    }

}
