using System;
using System.Diagnostics;
using System.Globalization;
using EficazFramework.Extensions;

#pragma warning disable CS8603 // Possível retorno de referência nula.

namespace EficazFramework.Converters;

internal class DocumentConverter<T> : MudBlazor.DefaultConverter<T>
{
    internal DocumentConverter()
    {
        _setCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        _setCulture.NumberFormat.PercentGroupSeparator = "";
        _setCulture.NumberFormat.CurrencyGroupSeparator = "";
        _setCulture.NumberFormat.NumberGroupSeparator = "";

        SetFunc = OnSet;
        GetFunc = OnGet;
    }

    private readonly CultureInfo _setCulture;
    public Enums.Documentos DocumentType { get; set; } = Enums.Documentos.CNPJ_CPF;
    public string UF { get; set; } = "EX";

    private T OnGet(string value)
    {
        try
        {
            return DocumentType switch
            {
                Enums.Documentos.eMail => (T)(object)value,
                _ => (T)(object)value.RemoveTextMask()
            };
        }
        catch (FormatException e)
        {
            UpdateGetError(e.Message);
            return default;
        }
    }

    private string OnSet(T value)
    {
        if (value == null)
            return null;

        string baseStr = value.ToString().RemoveTextMask();

        if (!decimal.TryParse(baseStr, out decimal test))
            return value.ToString();

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
}

#pragma warning restore CS8603 // Possível retorno de referência nula.
