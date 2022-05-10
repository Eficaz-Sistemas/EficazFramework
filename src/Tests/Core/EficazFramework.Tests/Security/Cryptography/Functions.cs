using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.Security.Cryptography;

public class TripleDES
{

    [Test]
    public void EncriptAndDecript()
    {
        var encripted = Cryptography.Functions.Encript("Hello World!", "#hdf@clm$cb#");
        Cryptography.Functions.Decript(encripted, "#hdf@clm$cb#").Should().Be("Hello World!");
        Cryptography.Functions.Decript(encripted, "badkey").Should().NotBe("Hello World!");
    }

}
