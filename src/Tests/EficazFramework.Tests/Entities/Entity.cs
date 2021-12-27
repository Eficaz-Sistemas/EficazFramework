using FluentAssertions;
using NUnit.Framework;
using EficazFramework.Validation.Fluent.Rules;
using System.ComponentModel.DataAnnotations;

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
    }

    //not working
    public void DataAnnotationValidationTest()
    {
        SampleClass instance = new()
        {
            ID = 0,
            Name = null,
            Mail = "testeerrado.com",
            Total = 5,
            ValidationMode = Enums.ValidationMode.Disabled
        };

        // disabled
        instance.Validate(null).Count.Should().Be(0);

        // datannotation
        instance.ValidationMode = Enums.ValidationMode.DataAnnotations;
        instance.Validate(null).Count.Should().Be(1);
    }

    [Test, Order(2)]
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


internal class SampleClass : EntityBase
{
    internal int ID { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "droga não pode ficar em branco.")]
    internal string Name { get; set; }
    internal string Mail { get; set; }
    internal string Document { get; set; }
    internal decimal Total { get; set; }
    internal string Obs { get; set; }
    internal System.DateTime CreatedIn { get; set; }
    internal string State { get; set; }

}
