#pragma warning disable BL0005 // Set parameter outside component
#pragma warning disable CS8625 // Não é possível converter um literal nulo em um tipo de referência não anulável.

using AwesomeAssertions;
using Bunit;
using EficazFramework.Tests;
using MudBlazor.Extensions;
using NUnit.Framework;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Components.Input;

[TestFixture]
public class NumberField : BunitTest
{
    [Test]
    [TestCase("InvariantCulture")]
    [TestCase("pt-BR")]
    [TestCase("en-US")]
    [TestCase("de-DE")]
    public async Task Test(string cultureName)
    {
        if (cultureName == "InvariantCulture")
            cultureName = CultureInfo.InvariantCulture.Name;

        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
        System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
        Console.WriteLine($"{cultureName} test");

        Console.WriteLine($"short");
        await TestIntNumberInternal<short>();   

        Console.WriteLine($"int");
        await TestIntNumberInternal<int>();

        Console.WriteLine($"long");
        await TestIntNumberInternal<long>();
        Console.WriteLine($"long?");

        Console.WriteLine($"ushort");
        await TestIntNumberInternal<ushort>();

        Console.WriteLine($"uint");
        await TestIntNumberInternal<uint>();

        await TestIntNumberInternal<ulong>();

        //Console.WriteLine($"Int128");
        //await TestIntNumberInternal<Int128>();
        //Console.WriteLine($"Int128?");
        //await TestIntNumberInternal<Int128?>();

        Console.WriteLine($"float");
        await TestDecimalNumberInternal<float>();

        Console.WriteLine($"double");
        await TestDecimalNumberInternal<double>();

        Console.WriteLine($"decimal");
        await TestDecimalNumberInternal<decimal>();
    }


    private async Task TestIntNumberInternal<T>() where T : struct, System.Numerics.INumber<T>
    {

        var comp = Context.Render<NumberField<T>>();
        var _converter = comp.Instance.Converter as Converters.NumberConverter<T>;
        _converter.Should().NotBeNull();

        Console.Write(_converter.Culture.Invoke().DisplayName);
        Console.WriteLine($"|{_converter.Culture.Invoke().NumberFormat.NumberDecimalSeparator}");
        Console.Write(comp.Instance.GetState(s => s.Culture).DisplayName);
        Console.WriteLine($"|{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberDecimalSeparator}");

        _converter.Culture.Invoke().Should().Be(comp.Instance.GetState(s => s.Culture));
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        await comp.Instance.FocusAsync();
        await input.ChangeAsync("5");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("5");
        comp.Instance.GetState(s => s.Value).Should().Be(5);

        //invalid dcimal places test...
        await comp.Instance.FocusAsync();
        await input.ChangeAsync($"5{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberDecimalSeparator}7");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("6");
        comp.Instance.GetState(s => s.Value).Should().Be(6);

        await comp.Instance.FocusAsync();
        await input.ChangeAsync($"5{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberDecimalSeparator}2");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("5");
        comp.Instance.GetState(s => s.Value).Should().Be(5);

        await comp.Instance.FocusAsync();
        await input.ChangeAsync($"5{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberGroupSeparator}2");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("52");
        comp.Instance.GetState(s => s.Value).Should().Be(52);

        Console.WriteLine("nullable tests...");
        // Renderiza o componente com T? (nullable)

    }

    [Test]
    private async Task TestDecimalNumberInternal<T>() where T : struct, System.Numerics.INumber<T>
    {
        var comp = Context.Render<NumberField<T>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<T>));
        var _converter = comp.Instance.Converter as Converters.NumberConverter<T>;
        _converter.Should().NotBeNull();
        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

        var input = comp.Find("input");

        //let's try some typing...
        await comp.Instance.FocusAsync();
        await input.ChangeAsync("5");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("5");
        Convert.ToDecimal(comp.Instance.GetState(s => s.Value)).Should().Be(5m);

        // 5.7 => 6
        await comp.Instance.FocusAsync();
        await input.ChangeAsync($"5{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberDecimalSeparator}7");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be("6");
        Convert.ToDecimal(comp.Instance.GetState(s => s.Value)).Should().Be(6m);

        // 5.7 => 5.7
        comp.Instance.DecimalPlaces = 1;
        await comp.Instance.FocusAsync();
        await input.ChangeAsync($"5{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberDecimalSeparator}7");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be($"5{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberDecimalSeparator}7");
        Convert.ToDecimal(comp.Instance.GetState(s => s.Value)).Should().Be(5.7m);

        // 5.77 => 5.8
        await comp.Instance.FocusAsync();
        await input.ChangeAsync($"5{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberDecimalSeparator}77");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be($"5{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberDecimalSeparator}8");
        Convert.ToDecimal(comp.Instance.GetState(s => s.Value)).Should().Be(5.8m);

        // 5,7 => 5.7
        await comp.Instance.FocusAsync();
        await input.ChangeAsync($"5{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberGroupSeparator}7");
        await input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
        comp.Instance.GetState(s => s.Text).Should().Be($"57{comp.Instance.GetState(s => s.Culture).NumberFormat.NumberDecimalSeparator}0");
        Convert.ToDecimal(comp.Instance.GetState(s => s.Value)).Should().Be(57.0m);
    }


    //    [Test]
    //    public void TestNonNumberAndEmpty()
    //    {
    //        var comp = Context.Render<NumberField<int>>();
    //        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<int>));
    //        var _converter = comp.Instance.Converter as Converters.NumberConverter<int>;
    //        _converter.Should().NotBeNull();
    //        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

    //        var input = comp.Find("input");

    //        //let's try some typing...
    //        comp.InvokeAsync(() =>
    //        {
    //            comp.Instance.FocusAsync();
    //            input.Change("non text...");
    //            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
    //        });
    //        comp.Instance.GetState(s => s.Text).Should().Be("0");
    //        comp.Instance.GetState(s => s.Value).Should().Be(0);

    //        comp.InvokeAsync(() =>
    //        {
    //            comp.Instance.FocusAsync();
    //            input.Change(null);
    //            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
    //        });
    //        comp.Instance.GetState(s => s.Text).Should().Be("0");
    //        comp.Instance.GetState(s => s.Value).Should().Be(0);

    //    }

    //    [Test]
    //    public void TestNullableNonNumberAndEmpty()
    //    {
    //        var comp = Context.Render<NumberField<int?>>();
    //        comp.Instance.Converter.Should().BeOfType(typeof(Converters.NumberConverter<int?>));
    //        var _converter = comp.Instance.Converter as Converters.NumberConverter<int?>;
    //        _converter.Should().NotBeNull();
    //        _converter?.DecimalPlaces.Should().Be(comp.Instance.DecimalPlaces);

    //        var input = comp.Find("input");

    //        //let's try some typing...
    //        comp.InvokeAsync(() =>
    //        {
    //            comp.Instance.FocusAsync();
    //            input.Change("non text...");
    //            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
    //        });
    //        comp.Instance.GetState(s => s.Text).Should().Be(null);
    //        comp.Instance.GetState(s => s.Value).Should().Be(null);

    //        comp.InvokeAsync(() =>
    //        {
    //            comp.Instance.FocusAsync();
    //            input.Change(null);
    //            input.BlurAsync(new Microsoft.AspNetCore.Components.Web.FocusEventArgs());
    //        });
    //        comp.Instance.GetState(s => s.Text).Should().Be(null);
    //        comp.Instance.GetState(s => s.Value).Should().Be(null);

    //    }

}
