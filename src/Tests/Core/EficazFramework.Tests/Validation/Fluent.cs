using EficazFramework.Configuration;
using EficazFramework.Validation.Fluent.Rules;
using AwesomeAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Validation;

public class FluentTests
{
    [Test, Order(0)]
    public void Init()
    {
        EficazFramework.Validation.Definitions.InitialValidationMode = Enums.ValidationMode.Fluent;
    }

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

        instance.Document = "07731253617";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "10608025000126";
        validator.Validate(instance).Should().NotBeNullOrEmpty();
    }

    [Test]
    public void CNPJ()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().CNPJ((e) => e.Document);

        SampleObject instance = new() { Document = "00000000000" };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "00000000000000";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = null;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "07731253619";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "10608025000126";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "4HIAT750VAMM20";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "B35VXBMLXF7683";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "BXOWWTTGH3Z167";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "R2YLGDOIY7CR38";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "7S1IE0E3RJGH68";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "WJ1F7AQ0YMUV35";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "SV6V0UPJGT5046";
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

        instance.Document = "00000000000";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "07731253619";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "10608025000126";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "10608025000125";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "07731253618";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "4HIAT750VAMM20";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "B35VXBMLXF7683";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "BXOWWTTGH3Z167";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "R2YLGDOIY7CR38";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "7S1IE0E3RJGH68";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "WJ1F7AQ0YMUV35";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "SV6V0UPJGT5046";
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
    public void PIS()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().PisPasep((e) => e.Document);

        SampleObject instance = new() { Document = "20476695850" };
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "20476695851";
        validator.Validate(instance).Should().NotBeNullOrEmpty();
    }

    [Test]
    public void MinLenght()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().MinLenght((e) => e.Obs, 6);

        SampleObject instance = new() { Obs = "Abc" };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Obs = "Abcdef";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Obs = "Abcdefg";
        validator.Validate(instance).Should().BeNullOrEmpty();
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
    public void RangeDouble()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Range((e) => e.Total2, 1.15d, 1.19d);

        SampleObject instance = new() { Total2 = 1.14d };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Total2 = 1.15d;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Total2 = 1.16d;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Total2 = 1.18d;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Total2 = 1.19d;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Total2 = 1.20d;
        validator.Validate(instance).Should().NotBeNullOrEmpty();


    }

    [Test]
    public void RangeDouble2()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Range((e) => e.Total, 1.15M, decimal.MaxValue);

        SampleObject instance = new() { Total = 1.14M };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Total = 1.15M;
        validator.Validate(instance).Should().BeNullOrEmpty();

        validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Range((e) => e.Total, decimal.MinValue, 1.15M);

        instance.Total = 1.16M;
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Total = 1.15M;
        validator.Validate(instance).Should().BeNullOrEmpty();
    }

    [Test]
    public void RangeInt16()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Range((e) => e.Inicio2, (short)1, (short)4);

        SampleObject instance = new() { Inicio2 = 0 };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Inicio2 = 1;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Inicio2 = 2;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Inicio2 = 3;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Inicio2 = 4;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Inicio2 = 5;
        validator.Validate(instance).Should().NotBeNullOrEmpty();


    }

    [Test]
    public void RangeInt64()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Range((e) => e.Inicio3, (long)1, (long)4);

        SampleObject instance = new() { Inicio3 = 0 };
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Inicio3 = 1;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Inicio3 = 2;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Inicio3 = 3;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Inicio3 = 4;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Inicio3 = 5;
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

        instance.CreatedIn = new System.DateTime(2020, 11, 3);
        Validation.Fluent.Rules.Range<SampleObject> rule = (Validation.Fluent.Rules.Range<SampleObject>)validator.ValidationRules[0];
        rule.MaximumDate = System.DateTime.MaxValue;
        validator.Validate(instance).Should().BeNullOrEmpty();

        rule.MaximumDate = new System.DateTime(2020, 11, 5);
        rule.MinimumDate = System.DateTime.MinValue;
        validator.Validate(instance).Should().BeNullOrEmpty();

    }

    [Test]
    public void RangePeriod()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().RangePeriodo((e) => e.Inicio, (e) => e.Fim);

        SampleObject instance = new() { Inicio = 1, Fim = 2 };
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Inicio = 2;
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Inicio = 3;
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        ((EficazFramework.Validation.Fluent.Rules.RangePeriod<SampleObject>)validator.ValidationRules[0]).AllowEquals = false;
        instance.Inicio = 2;
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().RangePeriodo(null, null);
        ((Fluent.Rules.RangePeriod<SampleObject>)validator.ValidationRules[0]).GetStartPropertyName().Should().BeNull();
        ((Fluent.Rules.RangePeriod<SampleObject>)validator.ValidationRules[0]).GetPropertyName().Should().BeNull();
    }

    [Test]
    public async Task Required()
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

        instance.Name = "hello world!";
        (await validator.ValidateAsync(instance)).Should().BeNullOrEmpty();
    }

    [Test]
    public void RequiredIf()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().RequiredIf((e) => e.Document, (e) => (e.Name ?? "").Contains("empresa"), true);

        SampleObject instance = new() { Name = null };
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Name = "";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Name = " ";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Name = "hello world!";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Name = "empresa";
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Document = "1";
        validator.Validate(instance).Should().BeNullOrEmpty();

        instance.Document = "";
        validator.Validate(instance).Should().BeNullOrEmpty();

        ((Validation.Fluent.Rules.RequiredIf<SampleObject>)validator.ValidationRules[0]).AllowEmpty = false;
        validator.Validate(instance).Should().NotBeNullOrEmpty();

        instance.Name = " ";
        validator.Validate(instance).Should().BeNullOrEmpty();
    }

    [Test]
    public void UniqueWhenInsert()
    {
        //SETUP
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
        Resources.Mocks.MockDbContext dbContext = new();
        dbContext.Database.EnsureCreated();

        var testId = System.Guid.NewGuid();
        dbContext.Add(new Resources.Mocks.Classes.Blog()
        {
            Id = testId,
            Name = $"Blog 1"
        });
        dbContext.SaveChanges();


        //TEST
        EficazFramework.Validation.Fluent.Validator<Resources.Mocks.Classes.Blog> validator = new EficazFramework.Validation.Fluent.Validator<Resources.Mocks.Classes.Blog>().Unique(e => e.Id, () => dbContext.Blogs);
        var newEntry = Entities.EntityBase.Create<Resources.Mocks.Classes.Blog>();
        newEntry.Id = testId;
        newEntry.Name = $"New Blog";
        var result = validator.Validate(newEntry);
        result.Should().HaveCount(1);
        result[0].Should().Be(string.Format(EficazFramework.Resources.Strings.Validation.NotUnique, testId));

        newEntry.Id = System.Guid.NewGuid();
        result = validator.Validate(newEntry);
        result.Should().HaveCount(0);

        //TEAR DOWN
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
        System.IO.File.Delete($"{DbConfiguration.SettingsPath}data_provider.json");
    }

    [Test]
    public void UniqueWhenUpdate()
    {
        //SETUP
        DbConfiguration.SettingsPath = $@"{Environment.CurrentDirectory}\";
        Resources.Mocks.MockDbContext dbContext = new();
        dbContext.Database.EnsureCreated();

        var testId = System.Guid.NewGuid();
        dbContext.Add(new Resources.Mocks.Classes.Blog()
        {
            Id = testId,
            Name = $"Blog 1"
        });
        dbContext.SaveChanges();


        //TEST
        EficazFramework.Validation.Fluent.Validator<Resources.Mocks.Classes.Blog> validator = new EficazFramework.Validation.Fluent.Validator<Resources.Mocks.Classes.Blog>().Unique(e => e.Id, () => dbContext.Blogs);
        var entry = dbContext.Blogs.FirstOrDefault();
        var result = validator.Validate(entry);
        result.Should().HaveCount(0);

        entry.Id = System.Guid.NewGuid();
        result = validator.Validate(entry);
        result.Should().HaveCount(0);

        //TEAR DOWN
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
        System.IO.File.Delete($"{DbConfiguration.SettingsPath}data_provider.json");
    }


    [Test]
    public void Equals()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Equals((e) => e.Name, (e) => e.Name);
        SampleObject instance = new() { Name = "equality" };
        validator.Validate(instance).Should().BeNullOrEmpty();

        validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>().Equals((e) => e.Name, (e) => "not equal");
        validator.Validate(instance).Should().NotBeNullOrEmpty();
    }

    [Test]
    public void ValidationResultTest()
    {
        var instance = EficazFramework.Validation.Fluent.ValidationResult.NullInstance;
        instance.Should().HaveCount(1);
        instance[0].Should().Be(EficazFramework.Resources.Strings.Validation.NullInstance);

        var instance2 = EficazFramework.Validation.Fluent.ValidationResult.Empty;
        instance2.Should().HaveCount(0);
    }

    [Test]
    public void ExceptionString()
    {
        var result = Validation.Fluent.ValidationResult.GetValidationException("Name", new System.Exception("só testando"));
        result.Should().HaveCount(1);
        result[0].Should().Be(string.Format(Resources.Strings.Validation.ValidationException, "Name", "só testando"));
    }

    [Test]
    public void CustomExpression()
    {
        EficazFramework.Validation.Fluent.Validator<SampleObject> validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>()
            .CustomExpression((e) => (e.Name ?? "").Length == 5, (e) => $"O nome '{e.Name}' deve ter 5 caracteres e possui {(e.Name ?? "").Length}");

        SampleObject instance = new() { Name = null };
        var result = validator.Validate(instance);
        result.Should().HaveCount(1);
        result[0].Should().Be("O nome '' deve ter 5 caracteres e possui 0");

        instance.Name = "";
        result = validator.Validate(instance);
        result.Should().HaveCount(1);
        result[0].Should().Be("O nome '' deve ter 5 caracteres e possui 0");

        instance.Name = "Henrique";
        result = validator.Validate(instance);
        result.Should().HaveCount(1);
        result[0].Should().Be("O nome 'Henrique' deve ter 5 caracteres e possui 8");

        instance.Name = "Arara";
        result = validator.Validate(instance);
        result.Should().HaveCount(0);

        //
        instance.Name = "Henrique";
        validator = new EficazFramework.Validation.Fluent.Validator<SampleObject>()
            .CustomExpression((e) => e.Name == null || e.Name.Length == 5, null);
        result = validator.Validate(instance);
        result.Should().HaveCount(1);
        result[0].Should().Be(Resources.Strings.Validation.Expression_DefaultErrorMessage);
        
    }
}


internal class SampleObject
{
    internal int ID { get; set; }
    internal string Name { get; set; }
    internal bool IsActive { get; set; }
    internal string Mail { get; set; }
    internal string Document { get; set; }
    internal decimal Total { get; set; }
    internal double Total2 { get; set; }
    internal decimal? NullableTotal { get; set; }
    internal string Obs { get; set; }
    internal System.DateTime CreatedIn { get; set; }
    internal string State { get; set; }
    internal int Inicio { get; set; }
    internal int Fim { get; set; }
    internal short Inicio2 { get; set; }
    internal short Fim2 { get; set; }
    internal long Inicio3 { get; set; }
    internal long Fim3 { get; set; }
    public List<SampleObjectChild> Children { get; set; } = new List<SampleObjectChild>();

    public int RelatedID { get; set; }
    public SampleRelatedObject Related { get; set; }

}

internal class SampleObjectChild
{
    internal int ParentID { get; set; }
    internal SampleObject Parent { get; set; }
    internal int ID { get; set; }
    internal string Name { get; set; }
}

internal class SampleRelatedObject
{
    public int ID { get; set; }
}