#pragma warning disable BL0005 // Set parameter outside component

using Bunit;
using EficazFramework.Tests;
using AwesomeAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Components.DataViews;

[TestFixture]
public class ExpressionBuilder : BunitTest
{
    [Test, Order(1)]
    public async Task CreateExpressionBuilderTest()
    {
        // with null ViewModel (and no MudTable)
        var view = Context.RenderComponent<EficazFramework.Tests.Blazor.Views.TestComponents.DataViews.ExpressionBuilderTest>();
        var comp = view.FindComponent<Components.ExpressionBuilder>();
        comp.Instance.ViewModel.Should().BeNull();

        // applying the ViewModel
        await comp.InvokeAsync(() => comp.Instance.ViewModel = new());
        comp.Render();
        Console.WriteLine(comp.Markup);
        comp.FindAll("th").Count.Should().Be(4);
        comp.FindAll("td").Count.Should().Be(0); // no rows

        // add expression execute
        var buttons = comp.FindAll("button");
        await buttons[0].ClickAsync(new Microsoft.AspNetCore.Components.Web.MouseEventArgs()
        {
            Button = 0
        });
        comp.FindAll("th").Count.Should().Be(4);
        comp.FindAll("td").Count.Should().Be(4); // single row
        comp.Instance.ViewModel.Items.Should().HaveCount(1);

        // remove expression execute
        buttons = comp.FindAll("button");
        await buttons[1].ClickAsync(new Microsoft.AspNetCore.Components.Web.MouseEventArgs()
        {
            Button = 0
        });
        comp.FindAll("th").Count.Should().Be(4);
        comp.FindAll("td").Count.Should().Be(0); // no rows
        comp.Instance.ViewModel.Items.Should().HaveCount(0);


        // lock new expressions
        await comp.InvokeAsync(() => comp.Instance.ViewModel.CanAddExpressions = false);
        comp.FindAll("td").Count.Should().Be(0); // no rows
        comp.FindAll("button").Should().HaveCount(1); // just find button
        await comp.InvokeAsync(() => comp.Instance.ViewModel.AddNewItemCommand.Execute(null));
        comp.FindAll("td").Count.Should().Be(0); // no rows after addnew attempt

        await comp.InvokeAsync(() => comp.Instance.OnAddCommand());
        comp.FindAll("td").Count.Should().Be(0); // no rows after another addnew attempt

        await comp.InvokeAsync(() => comp.Instance.OnDeleteCommand(new object()));
        comp.FindAll("td").Count.Should().Be(0); // no rows

    }

    [Test, Order(2)]
    public async Task CrudTest()
    {
        var page = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.DataViews.ExpressionBuilder>();
        var comp = page.FindComponent<Components.ExpressionBuilder>();

        comp.Should().NotBeNull();
        var viewModel = comp.Instance.ViewModel;
        viewModel.Items.Should().HaveCount(0);

        var buttons = comp.FindAll("button");
        await buttons[0].ClickAsync(new Microsoft.AspNetCore.Components.Web.MouseEventArgs()
        {
            Button = 0
        });
        viewModel.Items.First().Should().NotBeNull();
        viewModel.Items.Should().HaveCount(1);
        comp.FindAll("tr.mud-table-row").Count.Should().Be(2); // header + one row
        var entryRow = comp.FindComponent<MudBlazor.MudTr>();

        // property column
        var selector = entryRow.FindComponent<MudBlazor.MudSelect<Expressions.ExpressionProperty>>();
        selector.Should().NotBeNull();
        selector.Instance.SelectedValues.Should().HaveCount(0);
        selector.Instance.Value.Should().BeNull();

        // operator column
        var selectorOp = entryRow.FindComponent<MudBlazor.MudSelect<Enums.CompareMethod>>();
        selectorOp.Should().NotBeNull();
        selectorOp.Instance.SelectedValues.Should().HaveCount(0);

        // operator column
        var editorCl = entryRow.FindComponents<MudBlazor.MudTd>().Last();
        editorCl.Should().NotBeNull();
        editorCl.FindComponent<MudBlazor.MudText>().Markup.Should().Contain("...");

        // select 'ID' property
        await comp.InvokeAsync(() => selector.Instance.SelectOption(viewModel.Properties.First()));
        viewModel.Items.First().SelectedProperty.Should().NotBeNull();
        selector.Instance.Text.Should().Be(viewModel.Items.First().SelectedProperty.DisplayName); // 'Codigo'
        viewModel.Items[0].Operator.Should().Be(viewModel.Properties[0].DefaultOperator);
        viewModel.Items[0].Value1.Should().Be(viewModel.Properties[0].DefaultValue1);
        viewModel.Items[0].Value2.Should().Be(viewModel.Properties[0].DefaultValue2);
        selectorOp.Instance.Value.Should().Be(viewModel.Items[0].Operator);
        var textField = editorCl.FindComponent<EficazFramework.Components.NumberField<object>>();
        textField.Should().NotBeNull();
        textField.Instance.Value.Should().Be(viewModel.Items[0].Value1);

        // two-way binding test
        textField.Find("input").Change(5);
        comp.WaitForAssertion(() => textField.Instance.Text.Should().Be("5"));
        comp.WaitForAssertion(() => textField.Instance.Value.Should().Be(5));
        viewModel.Items[0].Value1.Should().Be(5);

        // select CreatedIn property:
        await comp.InvokeAsync(() => selector.Instance.SelectOption(viewModel.Properties[2]));
        selector.Instance.Text.Should().Be("Aniversário");
        selector.Instance.Text.Should().Be(viewModel.Items.First().SelectedProperty.DisplayName); // 'Aniversário'
        viewModel.Items[0].Operator.Should().Be(viewModel.Properties[2].DefaultOperator);
        viewModel.Items[0].Value1.Should().Be(viewModel.Properties[2].DefaultValue1);
        viewModel.Items[0].Value2.Should().Be(viewModel.Properties[2].DefaultValue2);
        selectorOp.Instance.Value.Should().Be(viewModel.Items[0].Operator);

        var dateRangeField = editorCl.FindComponent<MudBlazor.MudDateRangePicker>();
        dateRangeField.Should().NotBeNull();
        dateRangeField.Instance.DateRange.Start.Should().Be((DateTime?)viewModel.Items[0].Value1);
        dateRangeField.Instance.DateRange.End.Should().Be((DateTime?)viewModel.Items[0].Value2);

        // select Name property:
        await comp.InvokeAsync(() => selector.Instance.SelectOption(viewModel.Properties[1]));
        selector.Instance.Text.Should().Be("Nome");
        selector.Instance.Text.Should().Be(viewModel.Items.First().SelectedProperty.DisplayName); // 'Nome'
        viewModel.Items[0].Operator.Should().Be(viewModel.Properties[1].DefaultOperator);
        viewModel.Items[0].Value1.Should().Be(viewModel.Properties[1].DefaultValue1);
        viewModel.Items[0].Value2.Should().Be(viewModel.Properties[1].DefaultValue2);
        selectorOp.Instance.Value.Should().Be(viewModel.Items[0].Operator);

        var textFieldStr = editorCl.FindComponent<MudBlazor.MudTextField<object>>();
        textFieldStr.Should().NotBeNull();
        textFieldStr.Instance.Value.Should().Be((string)viewModel.Items[0].Value1);

        // two-way binding test
        textFieldStr.Find("input").Change("Miguel");
        comp.WaitForAssertion(() => textFieldStr.Instance.Text.Should().Be("Miguel"));
        comp.WaitForAssertion(() => textFieldStr.Instance.Value.Should().Be("Miguel"));
        viewModel.Items[0].Value1.Should().Be("Miguel");

        var table = comp.FindComponent<EficazFramework.Components.Primitives.ExpressionBuilderTable>();
        table.Should().NotBeNull();
        table.Instance.SearchColumnFindRequest.Should().Be(comp.Instance.SearchColumnFindRequest);

        // select Related property:
        await comp.InvokeAsync(() => selector.Instance.SelectOption(viewModel.Properties[8]));
        selector.Instance.Text.Should().Be("Relacionado");
        selector.Instance.Text.Should().Be(viewModel.Items.First().SelectedProperty.DisplayName); // 'Relacionado'
        viewModel.Items[0].Operator.Should().Be(viewModel.Properties[8].DefaultOperator);
        viewModel.Items[0].Value1.Should().Be(viewModel.Properties[8].DefaultValue1);
        viewModel.Items[0].Value2.Should().Be(viewModel.Properties[8].DefaultValue2);
        selectorOp.Instance.Value.Should().Be(viewModel.Items[0].Operator);

        var autoCompl = editorCl.FindComponent<MudBlazor.MudAutocomplete<object>>();
        autoCompl.Should().NotBeNull();
        autoCompl.Instance.Value.Should().Be((string)viewModel.Items[0].Value1);
        await comp.InvokeAsync(() => autoCompl.Instance.FocusAsync());

        // disable custom expressions
        await comp.InvokeAsync(() => viewModel.CanBuildCustomExpressions = false);
        entryRow = comp.FindComponent<MudBlazor.MudTr>();
        entryRow.FindComponents<MudBlazor.MudSelect<Expressions.ExpressionProperty>>().Should().HaveCount(0);
        entryRow.FindComponents<MudBlazor.MudSelect<Enums.CompareMethod>>().Should().HaveCount(0);

        var readonlyCells = entryRow.FindComponents<MudBlazor.MudText>();
        readonlyCells.Should().HaveCount(2);
        readonlyCells[0].Markup.Should().Contain(viewModel.Items.First().SelectedProperty.DisplayName);
        readonlyCells[0].Markup.Should().Contain("Relacionado");
        readonlyCells[1].Markup.Should().Contain(EficazFramework.Extensions.Enums.GetLocalizedDescription(viewModel.Items.First().Operator));
        readonlyCells[1].Markup.Should().Contain(EficazFramework.Extensions.Enums.GetLocalizedDescription(Enums.CompareMethod.Equals));


        // select IsActive property:
        await comp.InvokeAsync(() => viewModel.CanBuildCustomExpressions = true);
        // property column
        selector = entryRow.FindComponent<MudBlazor.MudSelect<Expressions.ExpressionProperty>>();
        selector.Should().NotBeNull();
        selector.Instance.SelectedValues.Should().HaveCount(0);

        // operator column
        selectorOp = entryRow.FindComponent<MudBlazor.MudSelect<Enums.CompareMethod>>();
        selectorOp.Should().NotBeNull();
        selectorOp.Instance.SelectedValues.Should().HaveCount(0);

        // operator column
        editorCl = entryRow.FindComponents<MudBlazor.MudTd>().Last();
        editorCl.Should().NotBeNull();


        await comp.InvokeAsync(() => selector.Instance.SelectOption(viewModel.Properties[3]));
        editorCl.FindComponent<MudBlazor.MudCheckBox<object>>().Should().NotBeNull();
        selector.Instance.Text.Should().Be("Ativo");
        selector.Instance.Text.Should().Be(viewModel.Items.First().SelectedProperty.DisplayName); // 'Ativo'
        viewModel.Items[0].Operator.Should().Be(viewModel.Properties[3].DefaultOperator);
        viewModel.Items[0].Value1.Should().Be(viewModel.Properties[3].DefaultValue1);
        viewModel.Items[0].Value2.Should().Be(viewModel.Properties[3].DefaultValue2);
        viewModel.Items[0].Value1.Should().Be(true);
    }
}
