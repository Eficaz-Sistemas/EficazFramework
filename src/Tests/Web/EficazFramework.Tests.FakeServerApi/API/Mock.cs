using Bogus;
using System.Linq;

namespace EficazFramework.API;

internal static class Mock
{
    public static readonly IEnumerable<Resources.Mocks.Classes.MockClass> MockDb;
    
    static Mock()
    {
        var faker = new Faker<Resources.Mocks.Classes.MockClass>("pt_BR")
            .RuleFor(o => o.Id, f => f.UniqueIndex)
            .RuleFor(o => o.Name, f => f.Name.FullName());

        List<Resources.Mocks.Classes.MockClass> result = new();
        for (int i = 0; i < 5; i++)
        {
            result.Add(faker.Generate());
        }
        MockDb = result;
    }

    internal static async Task<IResult> GetAsync(EficazFramework.Expressions.QueryDescription? parameters)
    {
        await Task.Delay(1);
        List<Resources.Mocks.Classes.MockClass> result = new();
        
        var faker = new Faker<Resources.Mocks.Classes.MockClass>("pt_BR")
            .RuleFor(o => o.Id, f => f.Random.Int(1, 3))
            .RuleFor(o => o.Name, f => f.Name.FullName());

        for (int i = 0; i < 300; i++)
        {
            result.Add(faker.Generate());
        }
        if (parameters?.Filter != null)
            result = result.Where(EficazFramework.Expressions.ExpressionObjectQuery.GetExpression<Resources.Mocks.Classes.MockClass>(parameters.Filter).Compile()).ToList();
        
        return Results.Ok(result);
    }

    internal static async Task<IResult> GetBigAsync(EficazFramework.Expressions.QueryDescription parameters)
    {
        await Task.Delay(1);
        List<Resources.Mocks.Classes.MockClass> result = new();

        var faker = new Faker<Resources.Mocks.Classes.MockClass>("pt_BR")
            .RuleFor(o => o.Id, f => f.Random.Int(1, 1000))
            .RuleFor(o => o.Name, f => f.Name.FullName());

        for (int i = 0; i < 1500000; i++)
        {
            result.Add(faker.Generate());
        }
        if (parameters?.Filter != null)
            result = result.Where(EficazFramework.Expressions.ExpressionObjectQuery.GetExpression<Resources.Mocks.Classes.MockClass>(parameters.Filter).Compile()).ToList();

        return Results.Ok(result);
    }

    internal static IResult GetForCrudTest()
    {
        return Results.Ok(MockDb);
    }

    internal static IResult Update(Resources.Mocks.Classes.MockClass item)
    {
        var source = MockDb.Where(i => i.Id == item.Id).FirstOrDefault();

        if (source == null)
            return Results.NotFound(item);

        source.Name = item.Name;
        return Results.Ok(source);
    }

    internal static IResult ValidationFail()
    {
        IDictionary<string, string[]> errors = new Dictionary<string, string[]>();
        errors.Add("Validation", new[] { "Erro 001", "Erro 002" });
        return Results.ValidationProblem(errors, title: "Informações Inválidas", statusCode: 422);
    }

}
