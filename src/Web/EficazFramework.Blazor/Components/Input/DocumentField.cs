using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EficazFramework.Components;

public class DocumentField<T> : MudBlazor.MudTextField<T>
{
    public DocumentField() : base()
    {
        Converter = new Converters.DocumentConverter<T>() { DocumentType = DocumentType, UF = UF };
    }

    EficazFramework.Enums.Documentos _type = Enums.Documentos.CNPJ_CPF;
    [Parameter]
    public EficazFramework.Enums.Documentos DocumentType
    {
        get => _type;
        set
        {
            _type = value;
            ((Converters.DocumentConverter<T>)Converter).DocumentType = DocumentType;
            ((Converters.DocumentConverter<T>)Converter).UF = UF;
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
            ((Converters.DocumentConverter<T>)Converter).UF = UF;
        }
    }

    protected override Task OnBlurredAsync(FocusEventArgs obj)
    {
        base.OnBlurredAsync(obj);
        return SetTextAsync(Converter.Set(Value), false);
    }

}
