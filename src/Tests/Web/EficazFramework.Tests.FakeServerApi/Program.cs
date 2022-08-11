global using EficazFramework.Extensions;
global using EficazFramework.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/mock/get", async (EficazFramework.Expressions.QueryDescription parameters) => await EficazFramework.API.Mock.GetAsync(parameters));
app.MapPost("/mock/getBig", async (EficazFramework.Expressions.QueryDescription parameters) => await EficazFramework.API.Mock.GetBigAsync(parameters));

app.Run();
