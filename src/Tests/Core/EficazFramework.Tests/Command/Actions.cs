using AwesomeAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EficazFramework.Commands;

public class Actions

{
    private const string MyConfig = "MyConfig";
    private const int delay = 500;

    [Test]
    public void Invoke()
    {
        var parameters = new Dictionary<string, bool>
        {

            { MyConfig, false }
        };
        TimeSpan start = DateTime.Now.TimeOfDay;
        EficazFramework.Commands.DelayedAction.Invoke(() => CustomAction(parameters), delay);
        TimeSpan delta = DateTime.Now.TimeOfDay - start;
        delta.Milliseconds.Should().BeCloseTo(delay, 50);
        parameters[MyConfig].Should().Be(true);
    }

    [Test]
    public async Task InvokeAsync()
    {
        var parameters = new Dictionary<string, bool>
        {

            { MyConfig, false }
        };
        async void action() => await CustomActionAsync(parameters);
        TimeSpan start = DateTime.Now.TimeOfDay;
        CancellationTokenSource tks = new();
        await EficazFramework.Commands.DelayedAction.InvokeAsync(action, delay, tks.Token);
        tks.Cancel();
        Exception cEx = null;
        try
        {
            await EficazFramework.Commands.DelayedAction.InvokeAsync(action, delay, tks.Token);
            TimeSpan delta = DateTime.Now.TimeOfDay - start;
            delta.Milliseconds.Should().BeCloseTo(delay, 50);
        }
        catch (TaskCanceledException tex)
        {
            cEx = tex;
        }
        cEx.Should().NotBeNull();
    }

    private static void CustomAction(Dictionary<string, bool> config)
    {
        config[MyConfig] = true;
    }

    private static async Task CustomActionAsync(Dictionary<string, bool> config)
    {
        await Task.Delay(1);
        config[MyConfig] = true;
    }
}