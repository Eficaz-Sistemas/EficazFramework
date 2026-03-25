using EficazFramework.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddEficazFramework(options =>
{
    //options.Theme.Palette.Primary = new MudBlazor.Utilities.MudColor("#cacaca");
    //options.Theme.Palette.AppbarBackground = new MudBlazor.Utilities.MudColor("#00ffff");
    options.UseApplicationManager = true;
    options.ThemeIsDarkMode = true;
});


var app = builder.Build();

// pt-BR
string culture = "pt-BR";
var supportedCultures = new[] { new CultureInfo(culture) };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture: culture, uiCulture: culture),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});
System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
