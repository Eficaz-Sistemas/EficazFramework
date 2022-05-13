using EficazFramework.Extensions;
using System.Text.RegularExpressions;

namespace EficazFramework.Controls;

public class DocumentoInputBox : TextBox
{
    public DocumentoInputBox()
    {
        DataObject.AddPastingHandler(this, Pasting);
        Unloaded += OnUnload;
        //EficazFramework.docu
    }

    readonly Regex rg = new(@"[^\d]");

    #region Properties

    public string Value
    {
        get { return (string)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(string), typeof(DocumentoInputBox), new FrameworkPropertyMetadata(null,
                                                                                                                      FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                                      OnValueChanged, null, true,
                                                                                                                      System.Windows.Data.UpdateSourceTrigger.PropertyChanged));



    public EDocumentos Documento
    {
        get { return (EDocumentos)GetValue(DocumentoProperty); }
        set { SetValue(DocumentoProperty, value); }
    }
    public static readonly DependencyProperty DocumentoProperty =
        DependencyProperty.Register("Documento", typeof(EDocumentos), typeof(DocumentoInputBox), new FrameworkPropertyMetadata(EDocumentos.CNPJ_CPF,
                                                                                                                               FrameworkPropertyMetadataOptions.None,
                                                                                                                               OnDocumentoChanged, null, true,
                                                                                                                               System.Windows.Data.UpdateSourceTrigger.PropertyChanged));



    public string UF
    {
        get { return (string)GetValue(UFProperty); }
        set { SetValue(UFProperty, value); }
    }
    public static readonly DependencyProperty UFProperty =
        DependencyProperty.Register("UF", typeof(string), typeof(DocumentoInputBox), new FrameworkPropertyMetadata(null,
                                                                                                                   FrameworkPropertyMetadataOptions.None,
                                                                                                                   OnDocumentoChanged, null, true,
                                                                                                                   System.Windows.Data.UpdateSourceTrigger.PropertyChanged));



    #endregion

    #region Handlers

    private static void OnValueChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        DocumentoInputBox input = (DocumentoInputBox)source;
        string formated_value = null;

        if (e.NewValue != null)
            formated_value = input.FormatText(e.NewValue.ToString());

        if (input.Text != formated_value)
            input.Text = formated_value;
    }

    private static void OnDocumentoChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        DocumentoInputBox input = (DocumentoInputBox)source;
        string formated_value = null;

        if (input.Value != null)
            formated_value = input.FormatText(input.Value);

        if (input.Text != formated_value)
            input.Text = formated_value;
    }

    private void Pasting(object sender, DataObjectPastingEventArgs e)
    {
        if (e.DataObject.GetDataPresent(typeof(string)))
        {
            var pastedText = (string)e.DataObject.GetData(typeof(string));
            var selectedText = this.SelectedText;
            if (string.IsNullOrEmpty(selectedText))
                SetValue(DocumentoInputBox.TextProperty, ResolveValue(pastedText));
            else
                SetValue(DocumentoInputBox.TextProperty, ResolveValue((GetValue(DocumentoInputBox.TextProperty) ?? "").ToString().Replace(selectedText, pastedText)));
        }

        e.CancelCommand();
    }

    private void OnUnload(object sender, RoutedEventArgs e)
    {
        DataObject.RemovePastingHandler(this, Pasting);
        Unloaded -= OnUnload;
    }

    #endregion

    #region Overrides

    protected override void OnGotFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);
        if (this.IsKeyboardFocusWithin == false) return;
        SetValue(DocumentoInputBox.TextProperty, ResolveValue(Text));
    }

    protected override void OnLostFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);
        if (this.IsKeyboardFocusWithin == true) return;
        if (Value != Text) SetValue(DocumentoInputBox.ValueProperty, ResolveValue(Text));
        SetValue(DocumentoInputBox.TextProperty, FormatText(Text));
    }

    #endregion

    #region Helpers

    private string FormatText(string value)
    {
        return Documento switch
        {
            EDocumentos.CEP => value.FormatCEP(),
            EDocumentos.CNPJ or EDocumentos.CNPJ_CPF or EDocumentos.CPF => value.FormatRFBDocument(),
            EDocumentos.Fone => value.FormatFone(),
            EDocumentos.IE => value.FormatIE(UF),
            EDocumentos.PIS_NIT => value.FormatPIS(),
            _ => "",
        };
    }

    private string ResolveValue(string text)
    {
        return rg.Replace(text, string.Empty).Replace(System.Environment.NewLine, string.Empty);
    }

    #endregion

}

public enum EDocumentos
{
    CNPJ_CPF = 0,
    IE = 1,
    CEP = 2,
    Fone = 3,
    PIS_NIT = 4,
    CNPJ = 5,
    CPF = 6,
    eMail = 7,
    Custom = 99
}
