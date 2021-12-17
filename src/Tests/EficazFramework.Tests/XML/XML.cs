using EficazFramework.Serialization;
using EficazFramework.Shared;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace EficazFramework.XML;

public class OperationTests
{
    [Test]
    public void SignXmlDocument()
    {
        // Setup
        MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";
        SerializationOperations.ToXml(mockClass, target);
        System.Xml.XmlDocument source = XMLOperations.ToXmlDocument(target);
        System.IO.File.Delete(target);
        System.Security.Cryptography.X509Certificates.X509Certificate2 cert = MockCertificate();

        // Assert
        XMLOperations.SignXml(source, "Name", "MockClass", cert, true, true);
        Console.WriteLine(source.OuterXml);

        // Error message
        Exception ex = null;
        try
        {
            XMLOperations.SignXml(source, "Naame", "MockClassSS", cert, true, true);
        }
        catch (Exception e)
        {
            ex = e;
        }
        ex.Should().NotBeNull();

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
        System.Security.Cryptography.X509Certificates.X509Certificate2 cert = MockCertificate();

        // Assert
        XMLOperations.SignXml(ref sourceX, "Id", "MockClass", cert, true, true);
        Console.WriteLine(sourceX.ToString());

        // Error message
        Exception ex = null;
        try
        {
            XMLOperations.SignXml(ref sourceX, "IDd", "MockClassSS", cert, true, true);
        }
        catch (Exception e) 
        {
            ex = e;
        }
        ex.Should().NotBeNull();
    }

    [Test]
    public void ToXDocument()
    {
        // Setup
        MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";
        SerializationOperations.ToXml(mockClass, target);
        System.Xml.XmlDocument source = XMLOperations.ToXmlDocument(target);
        System.IO.File.Delete(target);

        // Assert
        System.Xml.Linq.XDocument result = XMLOperations.ToXDocument(source);
        result.Should().NotBeNull();
        result.Root.Name.ToString().Should().Be("MockClass");
        result.Root.Elements().ElementAt(0).Name.ToString().Should().Be("Id");
        result.Root.Elements().ElementAt(0).Value.Should().Be("1");
        result.Root.Elements().ElementAt(1).Name.ToString().Should().Be("Name");
        result.Root.Elements().ElementAt(1).Value.Should().Be("Henrique");
    }

    [Test]
    public void ToXmlDocument()
    {
        // Setup
        MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";

        // To string
        SerializationOperations.ToXml(mockClass, target);
        System.Xml.XmlDocument result = XMLOperations.ToXmlDocument(target);
        System.IO.File.Delete(target);
        result.Should().NotBeNull();

        // Assert
        result.DocumentElement.Name.Should().Be("MockClass");
        result.DocumentElement.ChildNodes[0].Name.Should().Be("Id");
        result.DocumentElement.ChildNodes[0].InnerText.Should().Be("1");
        result.DocumentElement.ChildNodes[1].Name.Should().Be("Name");
        result.DocumentElement.ChildNodes[1].InnerText.Should().Be("Henrique");

        // From XDocument
        System.Xml.Linq.XDocument source = XMLOperations.ToXDocument(result);
        source.Should().NotBeNull();
        System.Xml.XmlDocument result2 = XMLOperations.ToXmlDocument(source);
        result2.Should().NotBeNull();
        result2.DocumentElement.Name.Should().Be("MockClass");
        result2.DocumentElement.ChildNodes[0].Name.Should().Be("Id");
        result2.DocumentElement.ChildNodes[0].InnerText.Should().Be("1");
        result2.DocumentElement.ChildNodes[1].Name.Should().Be("Name");
        result2.DocumentElement.ChildNodes[1].InnerText.Should().Be("Henrique");
    }

    [Test]
    public async Task ToXmlDocumentAsync()
    {
        // Setup
        MockClass mockClass = new() { Id = 2, Name = "Eficaz" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";

        // To string
        await SerializationOperations.ToXmlAsync(mockClass, target);

        // To XmlDocument
        System.Xml.XmlDocument result = await XMLOperations.ToXmlDocumentAsync(target);
        System.IO.File.Delete(target);
        result.Should().NotBeNull();
        result.DocumentElement.Name.Should().Be("MockClass");
        result.DocumentElement.ChildNodes[0].Name.Should().Be("Id");
        result.DocumentElement.ChildNodes[0].InnerText.Should().Be("2");
        result.DocumentElement.ChildNodes[1].Name.Should().Be("Name");
        result.DocumentElement.ChildNodes[1].InnerText.Should().Be("Eficaz");
    }

    [Test]
    public void ToXElement()
    {
        // Setup
        MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";

        // To string
        SerializationOperations.ToXml(mockClass, target);
        System.Xml.XmlDocument source = XMLOperations.ToXmlDocument(target);
        System.IO.File.Delete(target);
        source.Should().NotBeNull();
      
        // Assert
        System.Xml.Linq.XElement test1 = XMLOperations.ToXElement((System.Xml.XmlElement)source.DocumentElement.ChildNodes[0]);
        test1.Name.ToString().Should().Be("Id");
        test1.Value.Should().Be("1");
      
        System.Xml.Linq.XElement test2 = XMLOperations.ToXElement((System.Xml.XmlElement)source.DocumentElement.ChildNodes[1]);
        test2.Name.ToString().Should().Be("Name");
        test2.Value.Should().Be("Henrique");
    }

    [Test]
    public void ToXmlElement()
    {
        // Setup
        MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";

        // To string
        SerializationOperations.ToXml(mockClass, target);
        System.Xml.XmlDocument source = XMLOperations.ToXmlDocument(target);
        System.IO.File.Delete(target);
        source.Should().NotBeNull();
        System.Xml.Linq.XDocument source1 = XMLOperations.ToXDocument(source);

        // Assert
        System.Xml.XmlElement test1 = XMLOperations.ToXmlElement(source1.Root.Elements().ElementAt(0));
        test1.Name.Should().Be("Id");
        test1.InnerText.Should().Be("1");

        System.Xml.XmlElement test2 = XMLOperations.ToXmlElement(source1.Root.Elements().ElementAt(1));
        test2.Name.Should().Be("Name");
        test2.InnerText.Should().Be("Henrique");
    }

    private static X509Certificate2 MockCertificate()
    {
        string target = $"{Environment.CurrentDirectory}/mockCertificate.pfxs";
        using var rsa = RSA.Create();
        var req = new CertificateRequest("cn=test", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        // Adding SubjectAlternativeNames (SAN)
        var subjectAlternativeNames = new SubjectAlternativeNameBuilder();
        subjectAlternativeNames.AddDnsName("test");
        req.CertificateExtensions.Add(subjectAlternativeNames.Build());

        var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddHours(1));

        // Create PFX (PKCS #12) with private key
        System.IO.File.WriteAllBytes(target, cert.Export(System.Security.Cryptography.X509Certificates.X509ContentType.Pfx, "1234"));

        cert = new(target, "1234");
        System.IO.File.Delete(target);
        return cert;
    }

}
