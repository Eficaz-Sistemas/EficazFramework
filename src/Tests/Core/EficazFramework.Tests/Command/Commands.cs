using AwesomeAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EficazFramework.Commands;

public class Commands

{
    private const string MyConfig = "MyConfig";

    [Test]
    public void Main()
    {
        EficazFramework.Commands.CommandBase cmd = new(MyCommand_Execute);
        cmd.Action.Should().NotBeNull();

        // Basic execution
        var parameters = new Dictionary<string, bool>
        {

            { MyConfig, false }
        };
        cmd.Execute(parameters);
        parameters[MyConfig].Should().Be(true);

        // Locking test
        cmd.IsEnabled = false;
        cmd.CanExecute(parameters).Should().Be(false);
        parameters[MyConfig] = false;
        cmd.Execute(parameters);
        parameters[MyConfig].Should().Be(false);
    }


    private void MyCommand_Execute(object sender, Events.ExecuteEventArgs e)
    {
        if (e.Parameter == null)
            throw new ArgumentNullException(nameof(e));

        var parameters = e.Parameter as Dictionary<string, bool>;
        parameters[MyConfig] = true;
    }
}
