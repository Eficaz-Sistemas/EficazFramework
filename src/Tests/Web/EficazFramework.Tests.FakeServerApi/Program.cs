global using EficazFramework.Extensions;
global using EficazFramework.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/mock/get", async (EficazFramework.Expressions.QueryDescription parameters) => await EficazFramework.API.Mock.GetAsync(parameters));
app.MapPost("/mock/getBig", async (EficazFramework.Expressions.QueryDescription parameters) => await EficazFramework.API.Mock.GetBigAsync(parameters));
app.MapPost("/mock/getForCrudTest", () => EficazFramework.API.Mock.GetForCrudTest());
app.MapPost("/mock/update", (EficazFramework.Shared.MockClass item) => EficazFramework.API.Mock.Update(item));


app.MapPost("/mock/fail/401", () => Results.Unauthorized());
app.MapPost("/mock/fail/403", () => Results.Forbid());
app.MapPost("/mock/fail/422", () => EficazFramework.API.Mock.ValidationFail());

app.Run();
