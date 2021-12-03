using EficazFramework.Serialization;
using EficazFramework.Shared;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EficazFramework.XML;

public class OperationTests
{

    public async Task SignXmlDocument()
    {

    }

    public async Task SignXDocument()
    {

    }

    [Test]
    public void ToXmlDocument()
    {
        // Setup
        MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";

        // To string
        SerializationOperations.ToXml(mockClass, target);

        // To XmlDocument
        System.Xml.XmlDocument result = XMLOperations.ToXmlDocument(target);
        System.IO.File.Delete(target);
        result.Should().NotBeNull();
        result.DocumentElement.Name.Should().Be("MockClass");
        result.DocumentElement.ChildNodes[0].Name.Should().Be("Id");
        result.DocumentElement.ChildNodes[0].InnerText.Should().Be("1");
        result.DocumentElement.ChildNodes[1].Name.Should().Be("Name");
        result.DocumentElement.ChildNodes[1].InnerText.Should().Be("Henrique");
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

}
