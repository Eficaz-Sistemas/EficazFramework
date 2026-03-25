using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Extensions;

namespace EficazFramework.Components;

public class DocumentField : MudBlazor.MudTextField<string>
{
    public DocumentField() : base()
    {
        Converter = new Converters.DocumentConverter() { DocumentType = DocumentType, UF = UF };
    }

    EficazFramework.Enums.Documentos _type = Enums.Documentos.CNPJ_CPF;
    [Parameter]
    public EficazFramework.Enums.Documentos DocumentType
    {
        get => _type;
        set
        {
            _type = value;
            ((Converters.DocumentConverter)Converter!).DocumentType = DocumentType;
            ((Converters.DocumentConverter)Converter!).UF = UF;
            //InputType = value switch
            //{
            //    Enums.Documentos.eMail or Enums.Documentos.Custom => MudBlazor.InputType.Text,
            //    _ => MudBlazor.InputType.Number,
            //};
        }
    }

    string _uf;
    [Parameter]
    public string UF
    {
        get => _uf;
        set
        {
            _uf = value;
            ((Converters.DocumentConverter)Converter!).UF = UF;
        }
    }

    protected override async Task OnBlurredAsync(FocusEventArgs obj)
    {
        await base.OnBlurredAsync(obj);
        await SetTextAsync(Converter!.Convert(this.GetState(x => x.Value) ?? ""));
    }

}
