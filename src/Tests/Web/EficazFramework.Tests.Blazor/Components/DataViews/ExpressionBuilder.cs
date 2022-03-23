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
            //with null ViewModel (and no MudTable)
            var comp = Context.RenderComponent<Components.ExpressionBuilder>();
            comp.Instance.ViewModel.Should().BeNull();


            //applying the ViewModel
            await comp.InvokeAsync(() => comp.Instance.ViewModel = new());
            comp.Render();
            Console.WriteLine(comp.Markup);
            comp.FindAll("th.ef-expression-table-cell").Count.Should().Be(1);

        }
    }
}
