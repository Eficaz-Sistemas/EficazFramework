global using EficazFramework.Extensions;
global using EficazFramework.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/mock/get", () => EficazFramework.API.Mock.GetAsync());
app.MapPost("/mock/getBig", () => EficazFramework.API.Mock.GetBigAsync());

app.Run();
