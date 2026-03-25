using EficazFramework.Extensions;
using System.Globalization;

namespace EficazFramework.Converters;

internal class DocumentConverter<T> : MudBlazor.IReversibleConverter<T, string>, MudBlazor.ICultureAwareConverter
{
    internal DocumentConverter()
    {
        _setCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        _setCulture.NumberFormat.PercentGroupSeparator = "";
        _setCulture.NumberFormat.CurrencyGroupSeparator = "";
        _setCulture.NumberFormat.NumberGroupSeparator = "";
        Culture = () => _setCulture;
    }

    private readonly CultureInfo _setCulture;
    public Enums.Documentos DocumentType { get; set; } = Enums.Documentos.CNPJ_CPF;
    public string UF { get; set; } = "EX";
    public Func<CultureInfo> Culture { get; set; }
    public Func<string?> Format { get; set; }

    public string Convert(T? input)
    {
        if (input == null)
            return null;

        string baseStr = input!.ToString()!.RemoveTextMask();

        if (!decimal.TryParse(baseStr, out decimal _))
            return input.ToString();

        return DocumentType switch
        {
            Enums.Documentos.CNPJ_CPF or Enums.Documentos.CNPJ or Enums.Documentos.CPF => baseStr.FormatRFBDocument(),
            Enums.Documentos.IE => baseStr.FormatIE(UF),
            Enums.Documentos.PIS_NIT => baseStr.FormatPIS(),
            Enums.Documentos.CEP => baseStr.FormatCEP(),
            Enums.Documentos.Fone => baseStr.FormatFone(),
            _ => "",
        };
    }

    public T ConvertBack(string input) =>
        DocumentType switch
        {
            Enums.Documentos.eMail => (T)(object)input,
            _ => (T)(object)input.RemoveTextMask()};
}