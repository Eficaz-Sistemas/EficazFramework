using System;
using System.Diagnostics;
using System.Globalization;
using EficazFramework.Extensions;

namespace EficazFramework.Converters
{
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

        private CultureInfo _setCulture;
        public Enums.Documentos DocumentType { get; set; } = Enums.Documentos.CNPJ_CPF;
        public string UF { get; set; }

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

            decimal test;
            if (!decimal.TryParse(value.ToString(), out test))
                return "";

            return DocumentType switch
            {
                Enums.Documentos.CNPJ_CPF or Enums.Documentos.CNPJ or Enums.Documentos.CPF => test.ToString(_setCulture).FormatRFBDocument(),
                Enums.Documentos.IE => test.ToString(_setCulture).FormatIE(UF),
                Enums.Documentos.PIS_NIT => test.ToString(_setCulture).FormataPIS(),
                Enums.Documentos.CEP => test.ToString(_setCulture).FormatCEP(),
                Enums.Documentos.Fone => test.ToString(_setCulture).FormatFone(),
                _ => "",
            };
        }
    }
}
