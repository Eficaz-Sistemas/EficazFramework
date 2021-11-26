using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Commands;

public class Actions

{
    private const string MyConfig = "MyConfig";
    private const int delay = 500;

    [Test, Order(1)]
    public void Invoke()
    {
        var parameters = new Dictionary<string, bool>
        {

            { MyConfig, false }
        };
        Action action = () => CustomAction(parameters);
        TimeSpan start = DateTime.Now.TimeOfDay;
        EficazFramework.Commands.DelayedAction.Invoke(action, delay);
        TimeSpan delta = DateTime.Now.TimeOfDay - start;
        delta.Milliseconds.Should().BeGreaterThanOrEqualTo(delay);
        parameters[MyConfig].Should().Be(true);
    }

    [Test, Order(2)]
    public async Task InvokeAsync()
    {
        var parameters = new Dictionary<string, bool>
        {

            { MyConfig, false }
        };
        async void action() => await CustomActionAsync(parameters);
        TimeSpan start = DateTime.Now.TimeOfDay;
        await EficazFramework.Commands.DelayedAction.InvokeAsync(action, delay, default);
        TimeSpan delta = DateTime.Now.TimeOfDay - start;
        delta.Milliseconds.Should().BeGreaterThanOrEqualTo(delay);
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