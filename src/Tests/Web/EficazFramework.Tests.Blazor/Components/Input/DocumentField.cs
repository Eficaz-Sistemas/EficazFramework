#pragma warning disable BL0005 // Set parameter outside component
#pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Bunit;
using NUnit.Framework;
using EficazFramework.Tests;
using Microsoft.AspNetCore.Components;

namespace EficazFramework.Components.Input;

[TestFixture]
public class DocumentField : BunitTest
{
    [Test]
    public async Task DocumentFieldTests()
    {
        var comp = Context.RenderComponent<DocumentField<string>>();
        comp.Instance.Converter.Should().BeOfType(typeof(Converters.DocumentConverter<string>));
        var _converter = comp.Instance.Converter as Converters.DocumentConverter<string>;
        _converter.Should().NotBeNull();
        _converter?.UF.Should().Be(comp.Instance.UF);
        _converter?.DocumentType.Should().Be(comp.Instance.DocumentType);


    }
}
