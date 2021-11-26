using FluentAssertions;
using NUnit.Framework;
using EficazFramework.Validation.Fluent.Rules;

namespace EficazFramework.Data.Validation;

public class Fluent
{
    [Test]
    public void Mail()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Mail((e) => e.Mail);

        SampleObject instance = new() { Mail = "Abc" };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Mail = "abc@def";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Mail = "abc@def.com";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Mail = "@def.com";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Mail = null;
        validator.Validate(instance).Should().BeNullOrEmpty();
    }

    [Test]
    public void CPF()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().CPF((e) => e.Document);

        SampleObject instance = new() { Document = "00000000000" };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = null;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "07731253619";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "10608025000126";
        validator.Validate(instance).Should().NotBeNullOrEmpty();
    }

    [Test]
    public void CNPJ()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().CNPJ((e) => e.Document);

        SampleObject instance = new() { Document = "00000000000" };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = null;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "07731253619";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "10608025000126";
        validator.Validate(instance).Should().BeNullOrEmpty();
    }

    [Test]
    public void CNPJouCPF()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().CNPJouCPF((e) => e.Document);

        SampleObject instance = new() { Document = "00000000000000" };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = null;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "07731253619";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "10608025000126";
        validator.Validate(instance).Should().BeNullOrEmpty();
    }

    [Test]
    public void InscricaoEstadual()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().InscricaoEstadual((e) => e.Document, (e) => e.State);

        SampleObject instance = new() { Document = "000000000000", State = "" };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "Isento";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.State = "SP";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "";
        instance.State = "";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.State = "SP";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = null;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "310422211114";
        instance.State = "SP";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.State = "MG";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.State = "";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.State = null;
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "10608025000126";
        instance.State = "SP";
        validator.Validate(instance).Should().NotBeNullOrEmpty();
    }

    [Test]
    public void MaxLenght()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().MaxLenght((e) => e.Obs, 6);

        SampleObject instance = new() { Obs = "Abc" };
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Obs = "Abcdef";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Obs = "Abcdefg";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Obs = "Abcdefghij";
        validator.Validate(instance).Should().NotBeNullOrEmpty();
    }

    [Test]
    public void Range()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Range((e) => e.Total, 1.15M, 1.19M);

        SampleObject instance = new() { Total = 1.14M };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Total = 1.15M;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Total = 1.16M;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Total = 1.18M;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Total = 1.19M;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Total = 1.20M;
        validator.Validate(instance).Should().NotBeNullOrEmpty();
    }

    [Test]
    public void RangeDate()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Range((e) => e.CreatedIn, new System.DateTime(2020, 11, 2), new System.DateTime(2020, 11, 5));

        SampleObject instance = new() { CreatedIn = new System.DateTime(2020, 11, 1) };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.CreatedIn = new System.DateTime(2020, 11, 2);
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.CreatedIn = new System.DateTime(2020, 11, 3);
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.CreatedIn = new System.DateTime(2020, 11, 4);
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.CreatedIn = new System.DateTime(2020, 11, 5);
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.CreatedIn = new System.DateTime(2020, 11, 6);
        validator.Validate(instance).Should().NotBeNullOrEmpty();
    }

    [Test]
    public void Required()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Required((e) => e.Name);

        SampleObject instance = new() { Name = null };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Name = "";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Name = " ";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Name = "hello world!";
        validator.Validate(instance).Should().BeNullOrEmpty();
    }

    [Test]
    public void RequiredIf()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().RequiredIf((e) => e.Name,
                                                                                                                                                                 when => when.Document == "123");

        SampleObject instance = new() { Name = "John", Document = "123" };
        validator.Validate(instance).Should().BeNullOrEmpty();
        instance.Document = "";
        validator.Validate(instance).Should().BeNullOrEmpty();
        instance.Document = "456";
        validator.Validate(instance).Should().BeNullOrEmpty();

        //
        instance.Name = "";
        instance.Document = "123";
        validator.Validate(instance).Should().NotBeNullOrEmpty();
        instance.Document = "";
        validator.Validate(instance).Should().BeNullOrEmpty();
        instance.Document = "456";
        validator.Validate(instance).Should().BeNullOrEmpty();

        //
        instance.Name = " ";
        instance.Document = "123";
        validator.Validate(instance).Should().BeNullOrEmpty();
        instance.Document = "";
        validator.Validate(instance).Should().BeNullOrEmpty();
        instance.Document = "456";
        validator.Validate(instance).Should().BeNullOrEmpty();

        //
        instance.Name = null;
        instance.Document = "123";
        validator.Validate(instance).Should().NotBeNullOrEmpty();
        instance.Document = "";
        validator.Validate(instance).Should().BeNullOrEmpty();
        instance.Document = "456";
        validator.Validate(instance).Should().BeNullOrEmpty();
    }

}


internal class SampleObject
{
    internal int ID { get; set; }
    internal string Name { get; set; }
    internal string Mail { get; set; }
    internal string Document { get; set; }
    internal decimal Total { get; set; }
    internal string Obs { get; set; }
    internal System.DateTime CreatedIn { get; set; }
    internal string State { get; set; }

}
