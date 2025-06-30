using AwesomeAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EficazFramework.Threading;

public class ModalAssistTests
{
    [Test]
    public async Task ReturnOK()
    {
        // Setup
        ModalAssist instance = new();
        var push = instance.Push();

        // Test
        instance.Release(Events.MessageResult.OK);
        Events.MessageResult result = await push;

        // Assert
        result.Should().Be(Events.MessageResult.OK);


        // null task check
        instance = new();
        instance.Release(Events.MessageResult.OK);

    }
}
