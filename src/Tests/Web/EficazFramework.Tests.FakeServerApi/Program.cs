global using EficazFramework.Extensions;
global using EficazFramework.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/mock/get", async () => await EficazFramework.API.Mock.GetAsync(null));
app.MapPost("/mock/get", async (EficazFramework.Expressions.QueryDescription parameters) => await EficazFramework.API.Mock.GetAsync(parameters));
app.MapGet("/mock/getBig", async () => await EficazFramework.API.Mock.GetBigAsync(null));
app.MapPost("/mock/getBig", async (EficazFramework.Expressions.QueryDescription parameters) => await EficazFramework.API.Mock.GetBigAsync(parameters));
app.MapGet("/mock/getForCrudTest", () => EficazFramework.API.Mock.GetForCrudTest());
app.MapPut("/mock/update", (EficazFramework.Resources.Mocks.Classes.MockClass item) => EficazFramework.API.Mock.Update(item));


app.MapGet("/mock/fail/401", () => Results.Unauthorized());
app.MapGet("/mock/fail/403", () => Results.Forbid());
app.MapGet("/mock/fail/422", () => EficazFramework.API.Mock.ValidationFail());

app.MapPost("/blog/get", (EficazFramework.Expressions.QueryDescription parameters) => EficazFramework.API.Blog.Get(parameters));
app.MapPut("/blog/put", (EficazFramework.Resources.Mocks.Classes.BlogEntity blog) => EficazFramework.API.Blog.Update(blog));
app.MapPost("/blog/post", (EficazFramework.Resources.Mocks.Classes.BlogEntity blog) => EficazFramework.API.Blog.Insert(blog));
app.MapDelete("/blog/delete/{blogId}", (string blogId) => EficazFramework.API.Blog.Delete(blogId));

app.Run();
