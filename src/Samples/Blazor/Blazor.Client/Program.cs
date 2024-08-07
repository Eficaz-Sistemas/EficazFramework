using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EficazFramework.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddEficazFramework(options =>
{
    options.UseApplicationManager = true;
    options.ThemeIsDarkMode = true;
});

await builder.Build().RunAsync();
