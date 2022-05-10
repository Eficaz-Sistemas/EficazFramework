#pragma warning disable BL0005 // Set parameter outside component
#pragma warning disable CS8625 // Não é possível converter um literal nulo em um tipo de referência não anulável.

using Bunit;
using EficazFramework.Tests;
using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.Components.Input;

[TestFixture]
public class NumberField : BunitTest
{
    [Test]
    public void TestShort()
    {
        var comp = Context.RenderComponent<NumberField<short>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<short>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<short>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52);
    }

    [Test]
    public void TestNullableShort()
    {
        var comp = Context.RenderComponent<NumberField<short?>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<short?>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<short?>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52);
    }

    [Test]
    public void TestInt()
    {
        var comp = Context.RenderComponent<NumberField<int>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<int>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<int>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52);
    }

    [Test]
    public void TestNullableInt()
    {
        var comp = Context.RenderComponent<NumberField<int?>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<int?>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<int?>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52);
    }

    [Test]
    public void TestLong()
    {
        var comp = Context.RenderComponent<NumberField<long>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<long>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<long>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5L);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6L);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5L);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52L);
    }

    [Test]
    public void TestNullableLong()
    {
        var comp = Context.RenderComponent<NumberField<long?>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<long?>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<long?>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5L);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6L);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5L);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52L);
    }

    [Test]
    public void TestFloat()
    {
        var comp = Context.RenderComponent<NumberField<float>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<float>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<float>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5F);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6F);

        comp.InvokeAsync(() =>
        {
            comp.Instance.DecimalPlaces = 1;
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
        comp.Instance.Value.Should().Be(5.7F);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "77"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "8"));
        comp.Instance.Value.Should().Be(5.8F);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberGroupSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "57", "0"));
        comp.Instance.Value.Should().Be(57F);

    }

    [Test]
    public void TestNullableFloat()
    {
        var comp = Context.RenderComponent<NumberField<float?>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<float?>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<float?>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5F);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6F);

        comp.InvokeAsync(() =>
        {
            comp.Instance.DecimalPlaces = 1;
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
        comp.Instance.Value.Should().Be(5.7F);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "77"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "8"));
        comp.Instance.Value.Should().Be(5.8F);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberGroupSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "57", "0"));
        comp.Instance.Value.Should().Be(57F);

    }

    [Test]
    public void TestDouble()
    {
        var comp = Context.RenderComponent<NumberField<double>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<double>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<double>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5D);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6D);

        comp.InvokeAsync(() =>
        {
            comp.Instance.DecimalPlaces = 1;
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
        comp.Instance.Value.Should().Be(5.7D);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "77"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "8"));
        comp.Instance.Value.Should().Be(5.8D);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberGroupSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "57", "0"));
        comp.Instance.Value.Should().Be(57D);

    }

    [Test]
    public void TestNullableDouble()
    {
        var comp = Context.RenderComponent<NumberField<double?>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<double?>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<double?>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5D);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6F);

        comp.InvokeAsync(() =>
        {
            comp.Instance.DecimalPlaces = 1;
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
        comp.Instance.Value.Should().Be(5.7D);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "77"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "8"));
        comp.Instance.Value.Should().Be(5.8D);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberGroupSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "57", "0"));
        comp.Instance.Value.Should().Be(57D);

    }

    [Test]
    public void TestDecimal()
    {
        var comp = Context.RenderComponent<NumberField<decimal>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<decimal>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<decimal>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5M);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6M);

        comp.InvokeAsync(() =>
        {
            comp.Instance.DecimalPlaces = 1;
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
        comp.Instance.Value.Should().Be(5.7M);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "77"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "8"));
        comp.Instance.Value.Should().Be(5.8M);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberGroupSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "57", "0"));
        comp.Instance.Value.Should().Be(57M);

    }

    [Test]
    public void TestNullableDecimal()
    {
        var comp = Context.RenderComponent<NumberField<decimal?>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<decimal?>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<decimal?>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5M);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6M);

        comp.InvokeAsync(() =>
        {
            comp.Instance.DecimalPlaces = 1;
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "7"));
        comp.Instance.Value.Should().Be(5.7M);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "77"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "5", "8"));
        comp.Instance.Value.Should().Be(5.8M);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(string.Join(comp.Instance.Culture.NumberFormat.NumberGroupSeparator, "5", "7"));
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(string.Join(comp.Instance.Culture.NumberFormat.NumberDecimalSeparator, "57", "0"));
        comp.Instance.Value.Should().Be(57M);

    }

    [Test]
    public void TestUShort()
    {
        var comp = Context.RenderComponent<NumberField<ushort>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<ushort>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<ushort>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52);
    }

    [Test]
    public void TestNullableUShort()
    {
        var comp = Context.RenderComponent<NumberField<ushort?>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<ushort?>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<ushort?>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52);
    }

    [Test]
    public void TestUInt()
    {
        var comp = Context.RenderComponent<NumberField<uint>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<uint>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<uint>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52);
    }

    [Test]
    public void TestNullableUInt()
    {
        var comp = Context.RenderComponent<NumberField<uint?>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<uint?>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<uint?>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52);
    }

    [Test]
    public void TestULong()
    {
        var comp = Context.RenderComponent<NumberField<ulong>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<ulong>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<ulong>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5L);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6L);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5L);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52L);
    }

    [Test]
    public void TestNullableULong()
    {
        var comp = Context.RenderComponent<NumberField<ulong?>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<ulong?>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<ulong?>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("5");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5L);

        //invalid dcimal places test...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}7");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("6");
        comp.Instance.Value.Should().Be(6L);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberDecimalSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("5");
        comp.Instance.Value.Should().Be(5L);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change($"5{comp.Instance.Culture.NumberFormat.NumberGroupSeparator}2");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("52");
        comp.Instance.Value.Should().Be(52L);
    }

    [Test]
    public void TestNonNumberAndEmpty()
    {
        var comp = Context.RenderComponent<NumberField<int>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<int>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<int>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("non text...");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("0");
        comp.Instance.Value.Should().Be(0);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(null);
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be("0");
        comp.Instance.Value.Should().Be(0);

    }

    [Test]
    public void TestNullableNonNumberAndEmpty()
    {
        var comp = Context.RenderComponent<NumberField<int?>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<int?>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<int?>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change("non text...");
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(null);
        comp.Instance.Value.Should().Be(null);

        comp.InvokeAsync(() =>
        {
            comp.Instance.FocusAsync();
            input.Change(null);
            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        });
        comp.Instance.Text.Should().Be(null);
        comp.Instance.Value.Should().Be(null);

    }

}
