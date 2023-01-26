using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

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

#if NET7_0_OR_GREATER

    [Test]
    public async Task EncriptAndDecriptAsync()
    {
        var encripted = Cryptography.Functions.Encript("Hello World!", "#hdf@clm$cb#");
        (await Cryptography.Functions.DecriptAsync(encripted, "#hdf@clm$cb#")).Should().Be("Hello World!");
        (await Cryptography.Functions.DecriptAsync(encripted, "badkey")).Should().NotBe("Hello World!");
    }

#endif

}
