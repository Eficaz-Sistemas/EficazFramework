using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace EficazFramework.Templates;

public partial class CookieConsent
{
    [Inject] public IJSRuntime JSRuntime { get; set; }
    [Inject] public MudBlazor.ISnackbar Snackbar { get; set; }
    [Parameter] public bool HasCookieConsent { get; set; }
    [Parameter] public string CookieConsentName { get; set; }
    [Parameter] public string Url { get; set; } = "http://eficazcs.com.br";

    private string RenderSnackBar()
    {
        Snackbar.Configuration.PositionClass = MudBlazor.Defaults.Classes.Position.BottomCenter;
        Snackbar.Add(new MarkupString(
            $@"<span>Utilizamos alguns cookies para autenticação e contato, mas para isto precisamos do seu consentimento.<br />Para ler nossa política de privacidade, <a href=""{Url}"" target=""_blank"" class=""mud-typography mud-link mud-primary-text mud-link-underline-always"" style=""color: var(--mud-palette-primary-text)!important"">clique aqui</a></span>"),
            MudBlazor.Severity.Info, config =>
            {
                config.Action = "Aceitar";
                config.ActionColor = MudBlazor.Color.Primary;
                config.ActionVariant = MudBlazor.Variant.Text;
                config.RequireInteraction = true;
                config.SnackbarVariant = MudBlazor.Variant.Filled;
                config.Onclick = (snackbar) =>
                {
                    Utilities.JsInterop.AcceptCookie(JSRuntime, CookieConsentName);
                    return Task.CompletedTask;
                };
            });
        return "";
    }
}
