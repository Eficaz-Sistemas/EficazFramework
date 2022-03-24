#pragma warning disable BL0005 // Set parameter outside component

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Bunit;
using NUnit.Framework;
using EficazFramework.Tests;

namespace EficazFramework.Components.DataViews
{
    [TestFixture]
    public class ExpressionBuilder : BunitTest
    {
        [Test, Order(1)]
        public async Task CreateExpressionBuilderTest()
        {
            // with null ViewModel (and no MudTable)
            var comp = Context.RenderComponent<Components.ExpressionBuilder>();
            comp.Instance.ViewModel.Should().BeNull();

            // applying the ViewModel
            await comp.InvokeAsync(() => comp.Instance.ViewModel = new());
            comp.Render();
            Console.WriteLine(comp.Markup);
            comp.FindAll("th").Count.Should().Be(4);
            comp.FindAll("th.mud-table-cell").Count.Should().Be(4);
            comp.FindAll("th.ef-expression-table-cell").Count.Should().Be(1);
            comp.FindAll("td.ef-expression-table-cell").Count.Should().Be(0); // no rows
            comp.FindAll("td").Count.Should().Be(0); // no rows
            comp.FindAll("col").Count.Should().Be(4);

            // add expression execute
            var buttons = comp.FindAll("button");
            await buttons[0].ClickAsync(new Microsoft.AspNetCore.Components.Web.MouseEventArgs() 
            {
                Button = 0
            });
            comp.FindAll("th.ef-expression-table-cell").Count.Should().Be(1);
            comp.FindAll("td.ef-expression-table-cell").Count.Should().Be(4); // single row
            comp.FindAll("td").Count.Should().Be(4); // no rows
            comp.Instance.ViewModel.Items.Should().HaveCount(1);

            // remove expression execute
            buttons = comp.FindAll("button");
            await buttons[1].ClickAsync(new Microsoft.AspNetCore.Components.Web.MouseEventArgs()
            {
                Button = 0
            });
            comp.FindAll("th.ef-expression-table-cell").Count.Should().Be(1);
            comp.FindAll("td").Count.Should().Be(0); // no rows
            comp.Instance.ViewModel.Items.Should().HaveCount(0);


            // lock new expressions
            await comp.InvokeAsync(() => comp.Instance.ViewModel.CanAddExpressions = false);
            comp.FindAll("th.ef-expression-table-cell").Count.Should().Be(0); // add command column not rendered
            comp.FindAll("td.ef-expression-table-cell").Count.Should().Be(0); // no rows
            comp.FindAll("col").Count.Should().Be(3); // add command column not rendered

        }
    }
}
