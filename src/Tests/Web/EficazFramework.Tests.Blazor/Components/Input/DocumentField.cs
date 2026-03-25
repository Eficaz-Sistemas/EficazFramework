using Bunit;
using EficazFramework.Tests;
using AwesomeAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using MudBlazor.Extensions;

namespace EficazFramework.Components.Input;

[TestFixture]
public class DocumentFieldTests : BunitTest
{
    [Test]
    public async Task Document_IE()
    {
        var comp = Context.Render<DocumentField>();
        comp.Instance.GetState(s => s.Converter).Should().BeOfType(typeof(Converters.DocumentConverter));
        var _converter = comp.Instance.GetState(s => s.Converter) as Converters.DocumentConverter;
        _converter.Should().NotBeNull();
        _converter?.UF.Should().Be(comp.Instance.UF);
        _converter?.DocumentType.Should().Be(comp.Instance.DocumentType);

        await comp.InvokeAsync(() =>
        {
            comp.Instance.UF = "MG";
            comp.Instance.DocumentType = Enums.Documentos.IE;
        });

        _converter?.UF.Should().Be("MG");
        _converter?.DocumentType.Should().Be(Enums.Documentos.IE);

        var input = comp.Find("input");

        //let's try some typing...
        await comp.Instance.FocusAsync();
        await input.ChangeAsync("non valid IE...");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("nonvalidIE");
        comp.Instance.GetState(s => s.Value).Should().Be("nonvalidIE");

        // valid IE for MG, expecting to set non-formated text
        await comp.Instance.FocusAsync();
        await input.ChangeAsync("512.846448.70-31");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("512.846448.70-31");
        comp.Instance.GetState(s => s.Value).Should().Be("5128464487031");

        // valid IE for MG, expecting to get formated text
        await comp.Instance.FocusAsync();
        await input.ChangeAsync("0022417780089");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("002.241778.00-89");
        comp.Instance.GetState(s => s.Value).Should().Be("0022417780089");

    }

    [Test]
    public async Task Document_CnpjCpf()
    {
        var comp = Context.Render<DocumentField>();
        comp.Instance.GetState(s => s.Converter).Should().BeOfType(typeof(Converters.DocumentConverter));
        var _converter = comp.Instance.GetState(s => s.Converter) as Converters.DocumentConverter;
        _converter.Should().NotBeNull();

        await comp.InvokeAsync(() =>
        {
            comp.Instance.DocumentType = Enums.Documentos.CNPJ_CPF;
        });
        _converter?.DocumentType.Should().Be(Enums.Documentos.CNPJ_CPF);

        var input = comp.Find("input");

        // CNPJ, expecting to set non-formated text
        await comp.Instance.FocusAsync();
        await input.ChangeAsync("10608025000126");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("10.608.025/0001-26");
        comp.Instance.GetState(s => s.Value).Should().Be("10608025000126");

        // CPF, expecting to set non-formated text
        await comp.Instance.FocusAsync();
        await input.ChangeAsync("07731253619");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("077.312.536-19");
        comp.Instance.GetState(s => s.Value).Should().Be("07731253619");


        // CNPJ again, typing with mask
        await comp.Instance.FocusAsync();
        await input.ChangeAsync("10.608.025/0001-26");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("10.608.025/0001-26");
        comp.Instance.GetState(s => s.Value).Should().Be("10608025000126");

        //non-number test:
        await comp.Instance.FocusAsync();
        await input.ChangeAsync(null);
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().BeNullOrEmpty();
        comp.Instance.GetState(s => s.Value).Should().BeNullOrEmpty();
    }

    [Test]
    public async Task Document_Pis()
    {
        var comp = Context.Render<DocumentField>();
        comp.Instance.GetState(s => s.Converter).Should().BeOfType(typeof(Converters.DocumentConverter));
        var _converter = comp.Instance.GetState(s => s.Converter) as Converters.DocumentConverter;
        _converter.Should().NotBeNull();

        await comp.InvokeAsync(() =>
        {
            comp.Instance.DocumentType = Enums.Documentos.PIS_NIT;
        });
        _converter?.DocumentType.Should().Be(Enums.Documentos.PIS_NIT);

        var input = comp.Find("input");

        // PIS, expecting to set non-formated text
        await comp.Instance.FocusAsync();
        await input.ChangeAsync("20685458924");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("206.85458.92-4");
        comp.Instance.GetState(s => s.Value).Should().Be("20685458924");


        // typing with mask
        await comp.Instance.FocusAsync();
        await input.ChangeAsync("204.76695.85-0");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("204.76695.85-0");
        comp.Instance.GetState(s => s.Value).Should().Be("20476695850");

    }

    [Test]
    public async Task Document_Fone()
    {
        var comp = Context.Render<DocumentField>();
        comp.Instance.GetState(s => s.Converter).Should().BeOfType(typeof(Converters.DocumentConverter));
        var _converter = comp.Instance.GetState(s => s.Converter) as Converters.DocumentConverter;
        _converter.Should().NotBeNull();

        await comp.InvokeAsync(() =>
        {
            comp.Instance.DocumentType = Enums.Documentos.Fone;
        });
        _converter?.DocumentType.Should().Be(Enums.Documentos.Fone);

        var input = comp.Find("input");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("5441245");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("544-1245");
        comp.Instance.GetState(s => s.Value).Should().Be("5441245");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("35441245");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("3544-1245");
        comp.Instance.GetState(s => s.Value).Should().Be("35441245");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("3535441245");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("(35) 3544-1245");
        comp.Instance.GetState(s => s.Value).Should().Be("3535441245");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("553535441245");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("+55 (35) 3544-1245");
        comp.Instance.GetState(s => s.Value).Should().Be("553535441245");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("999712741");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Value).Should().Be("999712741");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("16999712741");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("(16) 99971-2741");
        comp.Instance.GetState(s => s.Value).Should().Be("16999712741");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("5516999712741");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("+55 (16) 99971-2741");
        comp.Instance.GetState(s => s.Value).Should().Be("5516999712741");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("08001234567");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("0800 123 4567");
        comp.Instance.GetState(s => s.Value).Should().Be("08001234567");
    }

    [Test]
    public async Task Document_Cep()
    {
        var comp = Context.Render<DocumentField>();
        comp.Instance.GetState(s => s.Converter).Should().BeOfType(typeof(Converters.DocumentConverter));
        var _converter = comp.Instance.GetState(s => s.Converter) as Converters.DocumentConverter;
        _converter.Should().NotBeNull();

        await comp.InvokeAsync(() =>
        {
            comp.Instance.DocumentType = Enums.Documentos.CEP;
        });
        _converter?.DocumentType.Should().Be(Enums.Documentos.CEP);

        var input = comp.Find("input");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("799");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("799");
        comp.Instance.GetState(s => s.Value).Should().Be("799");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("3799");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("3-799");
        comp.Instance.GetState(s => s.Value).Should().Be("3799");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("37990");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("37-990");
        comp.Instance.GetState(s => s.Value).Should().Be("37990");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("379900");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("379-900");
        comp.Instance.GetState(s => s.Value).Should().Be("379900");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("7990000");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("7.990-000");
        comp.Instance.GetState(s => s.Value).Should().Be("7990000");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("37990000");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("37.990-000");
        comp.Instance.GetState(s => s.Value).Should().Be("37990000");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("037990000");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("037.990-000");
        comp.Instance.GetState(s => s.Value).Should().Be("037990000");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("0037990000");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("0.037.990-000");
        comp.Instance.GetState(s => s.Value).Should().Be("0037990000");
    }

    [Test]
    public async Task Document_Mail()
    {
        var comp = Context.Render<DocumentField>();
        comp.Instance.GetState(s => s.Converter).Should().BeOfType(typeof(Converters.DocumentConverter));
        var _converter = comp.Instance.GetState(s => s.Converter) as Converters.DocumentConverter;
        _converter.Should().NotBeNull();

        await comp.InvokeAsync(() =>
        {
            comp.Instance.DocumentType = Enums.Documentos.eMail;
        });
        _converter?.DocumentType.Should().Be(Enums.Documentos.eMail);

        var input = comp.Find("input");

        await comp.Instance.FocusAsync();
        await input.ChangeAsync("contato@eficazcs.com.br");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("contato@eficazcs.com.br");
        comp.Instance.GetState(s => s.Value).Should().Be("contato@eficazcs.com.br");
    }

}
