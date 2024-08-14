using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EficazFramework.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Globalization;
using System.Text.RegularExpressions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddLocalization();

builder.Services.AddHttpClient("EficazFramework.Sample.Blazor", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("EficazFramework.Sample.Blazor"));

builder.Services.AddEficazFramework(options =>
{
    options.UseApplicationManager = true;
    options.ThemeIsDarkMode = true;
});

var app = builder.Build(); //.RunAsync();

const string defaultCulture = "en-US";
var cultureInfo = CultureInfo.GetCultureInfo(defaultCulture);
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

await app.RunAsync();