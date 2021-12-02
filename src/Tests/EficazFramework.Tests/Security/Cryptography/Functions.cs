using FluentAssertions;
using NUnit.Framework;
using System;

namespace EficazFramework.Security.Cryptography;

public class TripleDES
{

    [Test]
    public void EncriptAndDecript()
    {
        var encripted = Cryptography.Functions.Encript("Hello World!", "#hdf@clm$cb#");
        Cryptography.Functions.Decript(encripted, "Hello World!");
    }

}
