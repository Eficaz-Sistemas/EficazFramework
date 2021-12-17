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
        docs.ElementAt(6).Description.Should().Be("eComparer_BiggerOrEqualThan");
        docs.ElementAt(6).ToString().Should().Be("eComparer_BiggerOrEqualThan");

    }

    [Test, Order(2)]
    public void GetLocalizedValues()
    {
        var valuesComp = Enums.GetLocalizedValues<EficazFramework.Enums.CompareMethod>();
        valuesComp.Count().Should().Be(12);
        valuesComp.ElementAt(6).Value.Should().Be(EficazFramework.Enums.CompareMethod.BiggerOrEqualThan);
        valuesComp.ElementAt(6).Description.Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_BiggerOrEqualThan);
        valuesComp.Count(c => c.Description == c.Value.ToString()).Should().Be(0);

        var valuesComp1 = Enums.GetLocalizedValues(typeof(EficazFramework.Enums.CompareMethod));
        valuesComp1.Count().Should().Be(12);
        valuesComp1.ElementAt(6).Value.Should().Be(EficazFramework.Enums.CompareMethod.BiggerOrEqualThan);
        valuesComp1.ElementAt(6).Description.Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_BiggerOrEqualThan);
        valuesComp1.ElementAt(6).ToString().Should().Be(EficazFramework.Resources.Strings.DataDescriptions.eComparer_BiggerOrEqualThan);
        valuesComp1.Count(c => c.Description == c.Value.ToString()).Should().Be(0);

        var valuesComp2 = Enums.GetLocalizedValues<DocumentosTeste>(typeof(EficazFramework.Resources.Strings.TestStrings));
        valuesComp2.Count().Should().Be(9);
        valuesComp2.ElementAt(4).Value.Should().Be(DocumentosTeste.PIS_NIT);
        valuesComp2.ElementAt(4).Description.Should().Be(EficazFramework.Resources.Strings.TestStrings.eDocumento_PIS_NIT);
        valuesComp2.Count(c => c.Description == c.Value.ToString()).Should().Be(7);

        var valuesComp3 = Enums.GetLocalizedValues(typeof(DocumentosTeste), typeof(EficazFramework.Resources.Strings.TestStrings));
        valuesComp3.Count().Should().Be(9);
        valuesComp3.ElementAt(4).Value.Should().Be(DocumentosTeste.PIS_NIT);
        valuesComp3.ElementAt(4).Description.Should().Be(EficazFramework.Resources.Strings.TestStrings.eDocumento_PIS_NIT);
        valuesComp3.Count(c => c.Description == c.Value.ToString()).Should().Be(7);
    }

    [Test, Order(3)]
    public void GetBoolValues()
    {
        _ = Resources.Strings.Descriptions.Culture;
        var values = Enums.GetBoolValues();
        values.Count().Should().Be(2);
        values.First(b => (bool)b.Value == true).Description.Should().Be("Sim");
        values.First(b => (bool)b.Value == false).Description.Should().Be("Não");
        values = Enums.GetBoolValues(BoolDescriptionType.TrueFalse);
        values.Count().Should().Be(2);
        values.First(b => (bool)b.Value == true).Description.Should().Be("Verdadeiro");
        values.First(b => (bool)b.Value == false).Description.Should().Be("Falso");
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
        contato.First().ToString().Should().Be("[Contato] CEP");

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
        var valuesComp = Enums.GetLocalizedValuesWithCategory<EficazFramework.Enums.CompareMethod>();
        valuesComp.Count().Should().Be(12);
        var gp = valuesComp.GroupBy(p => p.Category);
        gp.Count().Should().Be(1);
        gp.First().Count().Should().Be(12);

        var valuesComp1 = Enums.GetLocalizedValuesWithCategory(typeof(EficazFramework.Enums.CompareMethod));
        valuesComp1.Count().Should().Be(12);
        var gp1 = valuesComp1.GroupBy(p => p.Category);
        gp1.Count().Should().Be(1);
        gp1.First().Count().Should().Be(12);

        var valuesComp2 = Enums.GetLocalizedValuesWithCategory<DocumentosTeste>(typeof(EficazFramework.Resources.Strings.TestStrings));
        var gp2 = valuesComp2.GroupBy(p => p.Category).ToList();
        gp2.Count.Should().Be(2);
        gp2.First(k => k.Key == "Contato").Count().Should().Be(3);
        gp2.First(k => k.Key == "").Count().Should().Be(6);

        var valuesComp3 = Enums.GetLocalizedValuesWithCategory(typeof(DocumentosTeste), typeof(EficazFramework.Resources.Strings.TestStrings));
        var gp3 = valuesComp3.GroupBy(p => p.Category).ToList();
        gp3.Count.Should().Be(2);
        gp3.First(k => k.Key == "Contato").Count().Should().Be(3);
        gp3.First(k => k.Key == "").Count().Should().Be(6);
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
