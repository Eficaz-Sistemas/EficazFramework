﻿#pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída

using Bunit;
using EficazFramework.Tests;
using AwesomeAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EficazFramework.Components.Dialogs;
[TestFixture]
public class ViewModelDialog : BunitTest
{
    [Test]
    public async Task TestDialog()
    {
        var comp = Context.RenderComponent<Tests.Blazor.Views.Pages.Components.Dialogs.ViewModelDialog>();

        comp.FindAll("div.mud-dialog-container").Count.Should().Be(0); // init closed
        comp.FindAll("div.mud-dialog-title").Count.Should().Be(0); // init closed
        comp.FindAll("div.mud-dialog-content").Count.Should().Be(0); // init closed
        comp.FindAll("div.mud-dialog-actions").Count.Should().Be(0); // init closed

        // opening dialog - OK button
        Task.Delay(5000).ContinueWith(t =>
        {
            return true;
        });

        var buttons = comp.FindAll("button");
        comp.Instance.ShowDialog();
        await Task.Delay(5000);

    }
}
