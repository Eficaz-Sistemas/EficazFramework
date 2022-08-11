using Bogus;
using System.Linq;

namespace EficazFramework.API;

internal static class Mock
{
    internal static async Task<IResult> GetAsync(EficazFramework.Expressions.QueryDescription parameters)
    {
        await Task.Delay(1);
        List<Shared.MockClass> result = new();
        
        var faker = new Faker<Shared.MockClass>("pt_BR")
            .RuleFor(o => o.Id, f => f.Random.Int(1, 3))
            .RuleFor(o => o.Name, f => f.Name.FullName());

        for (int i = 0; i < 300; i++)
        {
            result.Add(faker.Generate());
        }
        if (parameters?.Filter != null)
            result = result.Where(EficazFramework.Expressions.ExpressionObjectQuery.GetExpression<Shared.MockClass>(parameters.Filter).Compile()).ToList();
        
        return Results.Ok(result);
    }

    internal static async Task<IResult> GetBigAsync(EficazFramework.Expressions.QueryDescription parameters)
    {
        await Task.Delay(1);
        List<Shared.MockClass> result = new();

        var faker = new Faker<Shared.MockClass>("pt_BR")
            .RuleFor(o => o.Id, f => f.Random.Int(1, 1000))
            .RuleFor(o => o.Name, f => f.Name.FullName());

        for (int i = 0; i < 1500000; i++)
        {
            result.Add(faker.Generate());
        }
        if (parameters?.Filter != null)
            result = result.Where(EficazFramework.Expressions.ExpressionObjectQuery.GetExpression<Shared.MockClass>(parameters.Filter).Compile()).ToList();

        return Results.Ok(result);
    }

}
