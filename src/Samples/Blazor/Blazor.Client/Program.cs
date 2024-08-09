using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EficazFramework.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient("EficazFramework.Sample.Blazor", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("EficazFramework.Sample.Blazor"));

builder.Services.AddEficazFramework(options =>
{
    options.UseApplicationManager = true;
    options.ThemeIsDarkMode = true;
});

await builder.Build().RunAsync();
