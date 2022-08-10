using Bogus;

namespace EficazFramework.API;

internal static class Mock
{
    internal static async Task<IResult> GetAsync()
    {
        await Task.Delay(1);
        List<Shared.MockClass> result = new();
        
        var faker = new Faker<Shared.MockClass>("pt_BR")
            .RuleFor(o => o.Id, f => f.Random.Int(1, 1000))
            .RuleFor(o => o.Name, f => f.Name.FullName());

        for (int i = 0; i < 300; i++)
        {
            result.Add(faker.Generate());
        }
        return Results.Ok(result);
    }

    internal static async Task<IResult> GetBigAsync()
    {
        await Task.Delay(1);
        List<Shared.MockClass> result = new();

        var faker = new Faker<Shared.MockClass>("pt_BR")
            .RuleFor(o => o.Id, f => f.Random.Int(1, 1000))
            .RuleFor(o => o.Name, f => f.Name.FullName());

        for (int i = 0; i < 150000; i++)
        {
            result.Add(faker.Generate());
        }
        return Results.Ok(result);
    }

}
