#pragma warning disable BL0005 // Set parameter outside component
#pragma warning disable CS8625 // Não é possível converter um literal nulo em um tipo de referência não anulável.

using Bunit;
using EficazFramework.Tests;
using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.Components.Input;

[TestFixture]
public class DocumentField : BunitTest
{
    [Test]
    public void Document_IE()
    {
        var comp = Context.RenderComponent<DocumentField<string>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.DocumentConverter<string>));
        var _converter = comp.Instance.Converter as Converters.DocumentConverter<string>;
        _converter.Should().NotBeNull();
        _converter?.UF.Should().Be(comp.Instance.UF);
        _converter?.DocumentType.Should().Be(comp.Instance.DocumentType);

        comp.InvokeAsync(() =>
        {
            comp.Instance.UF = "MG";
            comp.Instance.DocumentType = Enums.Documentos.IE;
        });

        _converter?.UF.Should().Be("MG");
        _converter?.DocumentType.Should().Be(Enums.Documentos.IE);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("non valid IE...");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("nonvalid");
        comp.Instance.Value.Should().Be("nonvalid");

        // valid IE for MG, expecting to set non-formated text
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("512.846448.70-31");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("512.846448.70-31");
        comp.Instance.Value.Should().Be("5128464487031");

        // valid IE for MG, expecting to get formated text
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("0022417780089");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("002.241778.00-89");
        comp.Instance.Value.Should().Be("0022417780089");

    }

    [Test]
    public void Document_CnpjCpf()
    {
        var comp = Context.RenderComponent<DocumentField<string>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.DocumentConverter<string>));
        var _converter = comp.Instance.Converter as Converters.DocumentConverter<string>;
        _converter.Should().NotBeNull();

        comp.InvokeAsync(() =>
        {
            comp.Instance.DocumentType = Enums.Documentos.CNPJ_CPF;
        });
        _converter?.DocumentType.Should().Be(Enums.Documentos.CNPJ_CPF);

        var input = comp.Find("input");

        // CNPJ, expecting to set non-formated text
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("10608025000126");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("10.608.025/0001-26");
        comp.Instance.Value.Should().Be("10608025000126");

        // CPF, expecting to set non-formated text
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("07731253619");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("077.312.536-19");
        comp.Instance.Value.Should().Be("07731253619");


        // CNPJ again, typing with mask
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("10.608.025/0001-26");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("10.608.025/0001-26");
        comp.Instance.Value.Should().Be("10608025000126");

        //non-number test:
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(null);
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(null);
        comp.Instance.Value.Should().Be(null);
    }

    [Test]
    public void Document_Pis()
    {
        var comp = Context.RenderComponent<DocumentField<string>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.DocumentConverter<string>));
        var _converter = comp.Instance.Converter as Converters.DocumentConverter<string>;
        _converter.Should().NotBeNull();

        comp.InvokeAsync(() =>
        {
            comp.Instance.DocumentType = Enums.Documentos.PIS_NIT;
        });
        _converter?.DocumentType.Should().Be(Enums.Documentos.PIS_NIT);

        var input = comp.Find("input");

        // PIS, expecting to set non-formated text
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("20685458924");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("206.85458.92-4");
        comp.Instance.Value.Should().Be("20685458924");


        // typing with mask
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("204.76695.85-0");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("204.76695.85-0");
        comp.Instance.Value.Should().Be("20476695850");

    }

    [Test]
    public void Document_Fone()
    {
        var comp = Context.RenderComponent<DocumentField<string>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.DocumentConverter<string>));
        var _converter = comp.Instance.Converter as Converters.DocumentConverter<string>;
        _converter.Should().NotBeNull();

        comp.InvokeAsync(() =>
        {
            comp.Instance.DocumentType = Enums.Documentos.Fone;
        });
        _converter?.DocumentType.Should().Be(Enums.Documentos.Fone);

        var input = comp.Find("input");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5441245");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("544-1245");
        comp.Instance.Value.Should().Be("5441245");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("35441245");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("3544-1245");
        comp.Instance.Value.Should().Be("35441245");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("3535441245");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("(35) 3544-1245");
        comp.Instance.Value.Should().Be("3535441245");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("553535441245");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("+55 (35) 3544-1245");
        comp.Instance.Value.Should().Be("553535441245");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("999712741");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("99971-2741");
        comp.Instance.Value.Should().Be("999712741");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("16999712741");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("(16) 99971-2741");
        comp.Instance.Value.Should().Be("16999712741");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5516999712741");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("+55 (16) 99971-2741");
        comp.Instance.Value.Should().Be("5516999712741");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("08001234567");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("0800 123 4567");
        comp.Instance.Value.Should().Be("08001234567");
    }

    [Test]
    public void Document_Cep()
    {
        var comp = Context.RenderComponent<DocumentField<string>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.DocumentConverter<string>));
        var _converter = comp.Instance.Converter as Converters.DocumentConverter<string>;
        _converter.Should().NotBeNull();

        comp.InvokeAsync(() =>
        {
            comp.Instance.DocumentType = Enums.Documentos.CEP;
        });
        _converter?.DocumentType.Should().Be(Enums.Documentos.CEP);

        var input = comp.Find("input");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("799");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("799");
        comp.Instance.Value.Should().Be("799");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("3799");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("3-799");
        comp.Instance.Value.Should().Be("3799");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("37990");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("37-990");
        comp.Instance.Value.Should().Be("37990");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("379900");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("379-900");
        comp.Instance.Value.Should().Be("379900");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("7990000");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("7.990-000");
        comp.Instance.Value.Should().Be("7990000");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("37990000");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("37.990-000");
        comp.Instance.Value.Should().Be("37990000");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("037990000");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("037.990-000");
        comp.Instance.Value.Should().Be("037990000");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("0037990000");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("0.037.990-000");
        comp.Instance.Value.Should().Be("0037990000");
    }

    [Test]
    public void Document_Mail()
    {
        var comp = Context.RenderComponent<DocumentField<string>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.DocumentConverter<string>));
        var _converter = comp.Instance.Converter as Converters.DocumentConverter<string>;
        _converter.Should().NotBeNull();

        comp.InvokeAsync(() =>
        {
            comp.Instance.DocumentType = Enums.Documentos.eMail;
        });
        _converter?.DocumentType.Should().Be(Enums.Documentos.eMail);

        var input = comp.Find("input");

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("contato@eficazcs.com.br");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("contato@eficazcs.com.br");
        comp.Instance.Value.Should().Be("contato@eficazcs.com.br");
    }

}
