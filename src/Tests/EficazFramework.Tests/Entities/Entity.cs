using FluentAssertions;
using NUnit.Framework;
using EficazFramework.Validation.Fluent.Rules;
using System.ComponentModel.DataAnnotations;
using System;

namespace EficazFramework.Entities;

public class EntityTests
{
    [Test, Order(1)]
    public void StateTest()
    {
        SampleClass instance1 = new();
        instance1.IsNew.Should().BeFalse();
        instance1.IsLoaded.Should().BeFalse();
        instance1.PostProcessed.Should().BeFalse();
        instance1.SetIsLoaded();
        instance1.IsLoaded.Should().BeTrue();
        instance1.Unload();
        instance1.IsLoaded.Should().BeFalse();
        instance1.PostProcessed = true;
        instance1.PostProcessed.Should().BeTrue();
        instance1.IsSelected.Should().BeFalse();

        SampleClass instance2 = EntityBase.Create<SampleClass>();
        instance2.IsNew.Should().BeTrue();
        instance2.IsLoaded.Should().BeTrue();
        instance2.PostProcessed.Should().BeFalse();
        instance2.UnSetNew();
        instance2.IsNew.Should().BeFalse();
        instance2.IsSelected = true;
        instance2.IsSelected.Should().BeTrue();

        Exception ex = null;
        try
        {
            _ = EntityBase.Create<SystemException>();
        }
        catch (Exception affEx)
        {
            ex = affEx;
        }
        ex.Should().NotBeNull();
    }

    //not working
    [Test, Order(1)]
    public void DataAnnotationValidationTest()
    {
        SampleClass instance = new()
        {
            ID = 0,
            Name = null,
            Mail = "testeerrado.com",
            Document = "123",
            CPF = "123",
            CNPJ = "123",
            IE = "111",
            UF = "MG",
            Total = 5,
            ValidationMode = Enums.ValidationMode.Disabled
        };

        // disabled
        instance.Validate(null).Count.Should().Be(0);

        // datannotation
        instance.ValidationMode = Enums.ValidationMode.DataAnnotations;
        instance.Validate(null).Count.Should().Be(6);

        instance.Document = "07731253620";
        instance.Validate(null).Count.Should().Be(6);

        instance.Document = "07731253619";
        instance.Validate(null).Count.Should().Be(5);

        instance.IE = "isento";
        instance.Validate(null).Count.Should().Be(4);

        instance.Document = "10608025000126";
        instance.Validate(null).Count.Should().Be(4);

        instance.Mail = "testeerrado@gmail.com";
        instance.Validate(null).Count.Should().Be(3);

        instance.CPF = "07731253619";
        instance.Validate(null).Count.Should().Be(2);

        instance.CNPJ = "10608025000126";
        instance.Validate(null).Count.Should().Be(1);

        instance.CNPJ = "10608025000127";
        instance.Validate(null).Count.Should().Be(2);

    }

    [Test, Order(2)]
    public void DataAnnotationAttributeTest()
    {
        EficazFramework.Validation.DataAnnotations.DocumentoRFB attr1 = new(Enums.DocumentosRFB.Ambos);
        attr1.IsValid(null).Should().BeTrue();
        attr1.IsValid("07731253619").Should().BeTrue();
        attr1.IsValid("07731253620").Should().BeFalse();
        attr1.IsValid("10608025000126").Should().BeTrue();
        attr1.IsValid("10608025000127").Should().BeFalse();
        attr1.Tipo = Enums.DocumentosRFB.CPF;
        attr1.IsValid("10608025000126").Should().BeFalse();
        attr1.IsValid("10608025000127").Should().BeFalse();
        attr1.IsValid("07731253619").Should().BeTrue();
        attr1.IsValid("07731253620").Should().BeFalse();
        attr1.Tipo = Enums.DocumentosRFB.CNPJ;
        attr1.IsValid("07731253619").Should().BeFalse();
        attr1.IsValid("07731253620").Should().BeFalse();
        attr1.IsValid("10608025000126").Should().BeTrue();
        attr1.IsValid("10608025000127").Should().BeFalse();

        EficazFramework.Validation.DataAnnotations.EMail attr2 = new();
        attr2.IsValid(null).Should().BeTrue();
        attr2.IsValid("teste").Should().BeFalse();
        attr2.IsValid("teste.com.br").Should().BeFalse();
        attr2.IsValid("teste@com.br").Should().BeTrue();
        attr2.IsValid("teste@teste.com.br").Should().BeTrue();
        attr2.IsValid("@teste.com.br").Should().BeFalse();
        EficazFramework.Validation.DataAnnotations.EMail.ValidateAddress(null).Should().Be(ValidationResult.Success);
        EficazFramework.Validation.DataAnnotations.EMail.ValidateAddress("teste").ErrorMessage.Should().NotBeNullOrEmpty();
        EficazFramework.Validation.DataAnnotations.EMail.ValidateAddress("teste.com.br").ErrorMessage.Should().NotBeNullOrEmpty();
        EficazFramework.Validation.DataAnnotations.EMail.ValidateAddress("teste@com.br").Should().Be(ValidationResult.Success);
        EficazFramework.Validation.DataAnnotations.EMail.ValidateAddress("teste@teste.com.br").Should().Be(ValidationResult.Success);
        EficazFramework.Validation.DataAnnotations.EMail.ValidateAddress("@teste.com.br").ErrorMessage.Should().NotBeNullOrEmpty();

        EficazFramework.Validation.DataAnnotations.IncricaoEstadual attr3 = new("MG");
        attr3.UFPropertyName.Should().Be("MG");
        attr3.IsValid(null).Should().BeTrue();
        attr3.IsValid("ISENTO").Should().BeTrue();
        attr3.IsValid("isento").Should().BeTrue();

    }

    [Test, Order(3)]
    public void FluentValidationTest()
    {
        SampleClass instance = new()
        {
            ID = 0,
            Name = null,
            Mail = "testeerrado.com",
            Document = "07731253619",
            Obs = null,
            CreatedIn = System.DateTime.Now,
            State = "ready",
            ValidationMode = Enums.ValidationMode.Disabled
        };

        // disabled
        instance.Validate(null).Count.Should().Be(0);

        // fluent
        instance.ValidationMode = Enums.ValidationMode.Fluent;
        instance.Validate(null).Count.Should().Be(0);
        instance.Validator = new Validation.Fluent.Validator<SampleClass>()
                                 .Range(o => o.ID, 1, 9)
                                 .Required(o => o.Name)
                                 .Mail(o => o.Mail)
                                 .CNPJouCPF(o => o.Document);
        instance.Validator.Should().NotBeNull();
        ((Collections.StringCollection)instance.GetErrors(nameof(instance.Name))).Should().HaveCount(1);
        instance.HasErrors.Should().BeTrue();
        instance.ReportErrorsChanged(nameof(SampleClass.Name));
        instance.ErrorText(nameof(instance.Name)).Length.Should().BeGreaterThan(0);
        instance.Validate(null).Count.Should().Be(3);
    }

}


public class SampleClass : EntityBase
{
    public int ID { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "droga não pode ficar em branco.")]
    public string Name { get; set; }

    [Validation.DataAnnotations.EMail()]
    public string Mail { get; set; }

    [Validation.DataAnnotations.DocumentoRFB(Enums.DocumentosRFB.Ambos)]
    public string Document { get; set; }

    [Validation.DataAnnotations.DocumentoRFB(Enums.DocumentosRFB.CPF)]
    public string CPF { get; set; }

    [Validation.DataAnnotations.DocumentoRFB(Enums.DocumentosRFB.CNPJ)]
    public string CNPJ { get; set; }


    [Validation.DataAnnotations.IncricaoEstadual("UF")]
    public string IE { get; set; }

    public string UF { get; set; }


    public decimal Total { get; set; }
    public string Obs { get; set; }
    public System.DateTime CreatedIn { get; set; }
    public string State { get; set; }

}
