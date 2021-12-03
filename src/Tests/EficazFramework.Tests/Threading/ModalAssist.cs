using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EficazFramework.Threading;

public class ModalAssistTests
{
    [Test]
    public async Task ReturnOK()
    {
        // Setup
        ModalAssist instance = new ();
        Events.MessageResult result = Events.MessageResult.NotSet;
        var push = instance.Push();

        // Test
        instance.Release(Events.MessageResult.OK);
        result = await push;

        // Assert
        result.Should().Be(Events.MessageResult.OK);

    }
}
