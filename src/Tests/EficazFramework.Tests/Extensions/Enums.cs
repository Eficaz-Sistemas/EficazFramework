using FluentAssertions;
using NUnit.Framework;
using EficazFramework.Extensions;
using System;
using System.Linq;

namespace EficazFramework.Extensions;

class Enum
{
    [Test, Order(1)]
    public void GetValues()
    {
        var enumValues = Enums.GetValues<ActionTargets>();
        enumValues.Count().Should().Be(3);

        Type enumtypetest = typeof(ActionTargets);
        var enumValues2 = Enums.GetValues(enumtypetest);
        enumValues2.Count().Should().Be(3);


        var docs = Enums.GetValues<EficazFramework.Enums.CompareMethod>();
        docs.Count().Should().Be(12);
        docs.ElementAt(6).Value.Should().Be(EficazFramework.Enums.CompareMethod.BiggerOrEqualThan);

    }

    [Test, Order(2)]
    public void GetLocalizedValues()
    {
        var valuesComp = Enums.GetLocalizedValues<EficazFramework.Enums.CompareMethod>("EficazFramework.Resources.Strings.DataDescriptions");
        valuesComp.Count().Should().Be(12);
        valuesComp.ElementAt(6).Value.Should().Be(EficazFramework.Enums.CompareMethod.BiggerOrEqualThan);
        valuesComp.ElementAt(6).Description.Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_BiggerOrEqualThan);
        valuesComp.Count(c => c.Description == c.Value.ToString()).Should().Be(0);

        Type enumtypetest = typeof(EficazFramework.Enums.CompareMethod);
        var enumValues2 = Enums.GetLocalizedValues(enumtypetest, "EficazFramework.Resources.Strings.DataDescriptions");
        enumValues2.Count().Should().Be(12);
        enumValues2.ElementAt(6).Value.Should().Be(EficazFramework.Enums.CompareMethod.BiggerOrEqualThan);
        enumValues2.ElementAt(6).Description.Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_BiggerOrEqualThan);
        enumValues2.Count(c => c.Description == c.Value.ToString()).Should().Be(0);

        var enumValues3 = Enums.GetLocalizedValues<DocumentosTeste>("EficazFramework.Resources.Strings.TestStrings");
        enumValues3.Count().Should().Be(9);
        enumValues3.ElementAt(4).Value.Should().Be(DocumentosTeste.PIS_NIT);
        enumValues3.ElementAt(4).Description.Should().Be(EficazFramework.Resources.Strings.TestStrings.eDocumento_PIS_NIT);
        enumValues3.ElementAt(7).Value.Should().Be(DocumentosTeste.eMail);
        enumValues3.ElementAt(7).Description.Should().Be(EficazFramework.Resources.Strings.TestStrings.eDocumento_eMail);
        enumValues3.Count(c => c.Description == c.Value.ToString()).Should().Be(7);

    }

    [Test, Order(3)]
    public void GetBoolValues()
    {
        var values = Enums.GetBoolValues();
        values.Count().Should().Be(2);
        values.First(b => (bool)b.Value == true).Description.Should().Be("Sim");
        values.First(b => (bool)b.Value == false).Description.Should().Be("Não");
    }

    [Test, Order(4)]
    public void GetValuesWithCategories()
    {
        var enumValues1 = Enums.GetValuesWithCategory<DocumentosTeste>();
        enumValues1.Count().Should().Be(9);
        var gp = enumValues1.GroupBy(p => p.Category);
        gp.Count().Should().Be(2);
        var contato = gp.First(gp => gp.Key == "Contato");
        contato.Count().Should().Be(3);

        var enumValues2 = Enums.GetValuesWithCategory(typeof(DocumentosTeste));
        enumValues2.Count().Should().Be(9);
        var gp2 = enumValues1.GroupBy(p => p.Category);
        gp2.Count().Should().Be(2);
        var contato2 = gp.First(gp => gp.Key == "Contato");
        contato2.Count().Should().Be(3);
    }

    [Test, Order(5)]
    public void GetLocalizedValuesWithCategories()
    {
        var enumValues1 = Enums.GetLocalizedValuesWithCategory<DocumentosTeste>("EficazFramework.Resources.Strings.TestStrings");
        enumValues1.Count().Should().Be(9);
        enumValues1.ElementAt(4).Value.Should().Be(DocumentosTeste.PIS_NIT);
        enumValues1.ElementAt(4).Description.Should().Be(EficazFramework.Resources.Strings.TestStrings.eDocumento_PIS_NIT);
        enumValues1.ElementAt(7).Value.Should().Be(DocumentosTeste.eMail);
        enumValues1.ElementAt(7).Description.Should().Be(EficazFramework.Resources.Strings.TestStrings.eDocumento_eMail);
        var gp = enumValues1.GroupBy(p => p.Category);
        gp.Count().Should().Be(2);
        var contato = gp.First(gp => gp.Key == "Contato");
        contato.Count().Should().Be(3);

        var enumValues2 = Enums.GetLocalizedValuesWithCategory(typeof(DocumentosTeste), "EficazFramework.Resources.Strings.TestStrings");
        enumValues2.Count().Should().Be(9);
        enumValues2.ElementAt(4).Value.Should().Be(DocumentosTeste.PIS_NIT);
        enumValues2.ElementAt(4).Description.Should().Be(EficazFramework.Resources.Strings.TestStrings.eDocumento_PIS_NIT);
        enumValues2.ElementAt(7).Value.Should().Be(DocumentosTeste.eMail);
        enumValues2.ElementAt(7).Description.Should().Be(EficazFramework.Resources.Strings.TestStrings.eDocumento_eMail);
        var gp2 = enumValues1.GroupBy(p => p.Category);
        gp2.Count().Should().Be(2);
        var contato2 = gp.First(gp => gp.Key == "Contato");
        contato2.Count().Should().Be(3);
    }


    public enum DocumentosTeste
    {
        CNPJ_CPF = 0,
        IE = 1,
        [System.ComponentModel.Category("Contato")]
        CEP = 2,
        [System.ComponentModel.Category("Contato")]
        Fone = 3,
        [Attributes.DisplayName("eDocumento_PIS_NIT")]
        PIS_NIT = 4,
        CNPJ = 5,
        CPF = 6,
        [System.ComponentModel.Category("Contato")]
        [System.ComponentModel.Description("eDocumento_eMail")]
        eMail = 7,
        Custom = 99
    }

}
