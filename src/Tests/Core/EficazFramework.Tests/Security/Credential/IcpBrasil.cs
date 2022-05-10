using EficazFramework.Serialization;
using EficazFramework.Shared;
using EficazFramework.XML;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

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


    [Test]
    public void SignXmlDocument()
    {
        // Setup
        MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";
        SerializationOperations.ToXml(mockClass, target);
        System.Xml.XmlDocument source = XMLOperations.ToXmlDocument(target);
        System.IO.File.Delete(target);

        target = $"{Environment.CurrentDirectory}/mockCertificate.pfxs";
        EficazFramework.Security.Credential.IcpBrasil icp1 = new(target, "1234");

        // null certificate
        Exception ex = null;
        try
        {
            icp1.SignXml(source, "Name", "MockClass", true, true);
        }
        catch (Exception e)
        {
            ex = e;
        }
        ex.Should().BeNull();
        Console.WriteLine(source.OuterXml);
    }

    [Test]
    public void SignXDocument()
    {
        // Setup
        MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";
        SerializationOperations.ToXml(mockClass, target);
        System.Xml.XmlDocument source = XMLOperations.ToXmlDocument(target);
        System.IO.File.Delete(target);
        System.Xml.Linq.XDocument sourceX = XMLOperations.ToXDocument(source);

        target = $"{Environment.CurrentDirectory}/mockCertificate.pfxs";
        EficazFramework.Security.Credential.IcpBrasil icp1 = new(target, "1234");

        // Error message
        Exception ex = null;
        try
        {
            icp1.SignXml(ref sourceX, "Id", "MockClass", true, true);
        }
        catch (Exception e)
        {
            ex = e;
        }
        ex.Should().BeNull();
        Console.WriteLine(sourceX.ToString());
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
