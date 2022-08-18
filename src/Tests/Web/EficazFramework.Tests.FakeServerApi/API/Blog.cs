using Bogus;
using System.Linq;

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

    internal static IResult Get()
    {
        return Results.Ok(BlogDb);
    }

    internal static IResult Update(Resources.Mocks.Classes.BlogEntity item)
    {
        var source = BlogDb.Where(i => i.Id == item.Id).FirstOrDefault();

        if (source == null)
            return Results.NotFound(item);

        source.Name = item.Name;
        return Results.Ok(source);
    }

}
