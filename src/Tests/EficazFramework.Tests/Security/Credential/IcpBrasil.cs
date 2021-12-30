using FluentAssertions;
using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EficazFramework.Security.Credential;

public class IcpBrasilTests
{
    System.Security.Cryptography.X509Certificates.X509Certificate2 cert = null;

    [SetUp]
    public void Setup()
    {
        cert = MockCertificate();
    }

    [TearDown]
    public void TearDown()
    {
        string target = $"{Environment.CurrentDirectory}/mockCertificate.pfxs";
        System.IO.File.Delete(target);
    }

    [Test]
    public void ReadPfx()
    {
        string target = $"{Environment.CurrentDirectory}/mockCertificate.pfxs";
        System.Security.Cryptography.X509Certificates.X509Certificate2 cert = MockCertificate();

        // read from file:
        EficazFramework.Security.Credential.IcpBrasil icp1 = new(target, "1234");
        icp1.AutoridadeCertificadora.Should().Be("EU MESMO");
        icp1.CNPJ_CPF.Should().Be("12.345.678/0001-00");
        icp1.Tipo.Should().Be("e-CNPJ");
        icp1.Titular.Should().Be("EFICAZ SISTEMAS");
        icp1.Validade.Value.Date.Should().Be(DateTime.Now.Date.AddDays(1).Date);

        // read raw data:
        var rawCert = System.IO.File.ReadAllBytes(target);
        rawCert.Should().NotBeNull();
        EficazFramework.Security.Credential.IcpBrasil icp2 = new(rawCert, cert, "1234");
        icp2.AutoridadeCertificadora.Should().Be("EU MESMO");
        icp2.CNPJ_CPF.Should().Be("12.345.678/0001-00");
        icp2.Tipo.Should().Be("e-CNPJ");
        icp2.Titular.Should().Be("EFICAZ SISTEMAS");
        icp2.Validade.Value.Date.Should().Be(DateTime.Now.Date.AddDays(1).Date);

    }

    [Test]
    public async System.Threading.Tasks.Task ListaRepositorio()
    {
        var list = Security.Credential.IcpBrasil.ListaCertificados(null, StoreLocation.CurrentUser);
        list.Should().NotBeNull();
        Console.WriteLine(list.Count);

        list = await Security.Credential.IcpBrasil.ListaCertificadosAsync(null, StoreLocation.CurrentUser);
        Console.WriteLine(list.Count);
    }



    private static X509Certificate2 MockCertificate()
    {
        string target = $"{Environment.CurrentDirectory}/mockCertificate.pfxs";
        using var rsa = RSA.Create();
        var req = new CertificateRequest("CN=EFICAZ SISTEMAS:12345678000100,OU=Autenticado por EU MESMO, OU=e-CNPJ", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        // Adding SubjectAlternativeNames (SAN)
        var subjectAlternativeNames = new SubjectAlternativeNameBuilder();
        subjectAlternativeNames.AddDnsName("test");
        req.CertificateExtensions.Add(subjectAlternativeNames.Build());

        var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(1));

        // Create PFX (PKCS #12) with private key
        System.IO.File.WriteAllBytes(target, cert.Export(System.Security.Cryptography.X509Certificates.X509ContentType.Pfx, "1234"));

        cert = new(target, "1234");
        return cert;
    }


}
