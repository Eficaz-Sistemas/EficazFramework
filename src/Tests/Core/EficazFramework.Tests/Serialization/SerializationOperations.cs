using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EficazFramework.Serialization;

public class Xml
{

    [Test]
    public void XmlStream()
    {
        // Setup
        Resources.Mocks.Classes.MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        System.IO.MemoryStream ms = new();

        // To Xml
        SerializationOperations.ToXml(mockClass, ms);
        Console.WriteLine(System.Text.Encoding.UTF8.GetString(ms.ToArray()));

        // From Xml (stream)
        ms.Position = 0;
        var assert = SerializationOperations.FromXml<Resources.Mocks.Classes.MockClass>(ms);
        assert.Id.Should().Be(1);
        assert.Name.Should().Be("Henrique");

        // To Xml (with XmlWriterSettings)
        ms = new();
        mockClass.Id = 7;
        mockClass.Name = "Eficaz";
        SerializationOperations.ToXml(mockClass, ms, new() { Indent = false, OmitXmlDeclaration = true });
        ms.Position = 0;
        Console.WriteLine(System.Text.Encoding.UTF8.GetString(ms.ToArray()));
        assert = SerializationOperations.FromXml<Resources.Mocks.Classes.MockClass>(ms);
        assert.Id.Should().Be(7);
        assert.Name.Should().Be("Eficaz");

    }

    [Test]
    public async Task XmlStreamAsync()
    {
        // Setup
        Resources.Mocks.Classes.MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        System.IO.MemoryStream ms = new();

        // To Xml
        await SerializationOperations.ToXmlAsync(mockClass, ms);
        Console.WriteLine(System.Text.Encoding.UTF8.GetString(ms.ToArray()));

        // From Xml (stream)
        ms.Position = 0;
        var assert = await SerializationOperations.FromXmlAsync<Resources.Mocks.Classes.MockClass>(ms);
        assert.Id.Should().Be(1);
        assert.Name.Should().Be("Henrique");

        // To Xml (with XmlWriterSettings)
        ms = new();
        mockClass.Id = 7;
        mockClass.Name = "Eficaz";
        await SerializationOperations.ToXmlAsync(mockClass, ms, new() { Indent = false, OmitXmlDeclaration = true });
        ms.Position = 0;
        Console.WriteLine(System.Text.Encoding.UTF8.GetString(ms.ToArray()));
        assert = await SerializationOperations.FromXmlAsync<Resources.Mocks.Classes.MockClass>(ms);
        assert.Id.Should().Be(7);
        assert.Name.Should().Be("Eficaz");
    }

    [Test]
    public void XmlFile()
    {
        // Setup
        Console.WriteLine(Environment.CurrentDirectory);
        Resources.Mocks.Classes.MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";

        // To Xml
        SerializationOperations.ToXml(mockClass, target);

        // From Xml (stream)
        var assert = SerializationOperations.FromXml<Resources.Mocks.Classes.MockClass>(target);
        assert.Id.Should().Be(1);
        assert.Name.Should().Be("Henrique");
        System.IO.File.Delete(target);

        // To Xml (with XmlWriterSettings)
        mockClass.Id = 7;
        mockClass.Name = "Eficaz";
        SerializationOperations.ToXml(mockClass, target, new() { Indent = false, OmitXmlDeclaration = true });
        assert = SerializationOperations.FromXml<Resources.Mocks.Classes.MockClass>(target);
        assert.Id.Should().Be(7);
        assert.Name.Should().Be("Eficaz");
        System.IO.File.Delete(target);
    }

    [Test]
    public async Task XmlFileAsync()
    {
        // Setup
        Console.WriteLine(Environment.CurrentDirectory);
        Resources.Mocks.Classes.MockClass mockClass = new() { Id = 1, Name = "Henrique" };
        string target = $"{Environment.CurrentDirectory}/mockClass.xml";

        // To Xml
        await SerializationOperations.ToXmlAsync(mockClass, target);

        // From Xml (stream)
        var assert = await SerializationOperations.FromXmlAsync<Resources.Mocks.Classes.MockClass>(target);
        assert.Id.Should().Be(1);
        assert.Name.Should().Be("Henrique");
        System.IO.File.Delete(target);

        // To Xml (with XmlWriterSettings)
        mockClass.Id = 7;
        mockClass.Name = "Eficaz";
        await SerializationOperations.ToXmlAsync(mockClass, target, new() { Indent = false, OmitXmlDeclaration = true });
        assert = await SerializationOperations.FromXmlAsync<Resources.Mocks.Classes.MockClass>(target);
        assert.Id.Should().Be(7);
        assert.Name.Should().Be("Eficaz");
        System.IO.File.Delete(target);
    }


}

public class Json
{
    [Test]
    public void JsonString()
    {
        // Setup
        Resources.Mocks.Classes.MockClass mockClass = new() { Id = 2, Name = "Miguel" };

        // To Json (string)
        string result = SerializationOperations.ToJson(mockClass);

        // From Json (string)
        var assert = SerializationOperations.FromJson<Resources.Mocks.Classes.MockClass>(result);
        assert.Id.Should().Be(2);
        assert.Name.Should().Be("Miguel");
    }

    [Test]
    public async Task JsonStringAsync()
    {
        // Setup
        Resources.Mocks.Classes.MockClass mockClass = new() { Id = 2, Name = "Miguel" };

        // To Json (string)
        string result = await SerializationOperations.ToJsonAsync(mockClass);

        // From Json (string)
        var assert = await SerializationOperations.FromJsonAsync<Resources.Mocks.Classes.MockClass>(result);
        assert.Id.Should().Be(2);
        assert.Name.Should().Be("Miguel");
    }

    [Test]
    public void JsonFile()
    {
        // Setup
        Resources.Mocks.Classes.MockClass mockClass = new() { Id = 2, Name = "Miguel" };
        string target = $"{Environment.CurrentDirectory}/mockClass.txt";

        // To Json (string)
        SerializationOperations.ToJsonFile(mockClass, target);

        // From Json (string)
        var assert = SerializationOperations.FromJsonFile<Resources.Mocks.Classes.MockClass>(target);
        assert.Id.Should().Be(2);
        assert.Name.Should().Be("Miguel");
        System.IO.File.Delete(target);
    }

    [Test]
    public async Task JsonFileAsync()
    {
        // Setup
        Resources.Mocks.Classes.MockClass mockClass = new() { Id = 2, Name = "Miguel" };
        string target = $"{Environment.CurrentDirectory}/mockClass.txt";

        // To Json (string)
        await SerializationOperations.ToJsonFileAsync(mockClass, target);

        // From Json (string)
        var assert = await SerializationOperations.FromJsonFileAsync<Resources.Mocks.Classes.MockClass>(target);
        assert.Id.Should().Be(2);
        assert.Name.Should().Be("Miguel");
        System.IO.File.Delete(target);
    }

    [Test]
    public void JsonStream()
    {
        // Setup
        Resources.Mocks.Classes.MockClass mockClass = new() { Id = 2, Name = "Miguel" };
        System.IO.MemoryStream ms = new();
        string plain = SerializationOperations.ToJson(mockClass);
        Console.WriteLine(plain);
        System.IO.StreamWriter sw = new(ms) { AutoFlush = true };
        sw.Write(plain);
        ms.Position = 0;

        // From Json (stream)
        var assert = SerializationOperations.FromJson<Resources.Mocks.Classes.MockClass>(ms);
        assert.Id.Should().Be(2);
        assert.Name.Should().Be("Miguel");
    }

    [Test]
    public async Task JsonStreamAsync()
    {
        // Setup
        Resources.Mocks.Classes.MockClass mockClass = new() { Id = 2, Name = "Miguel" };
        System.IO.MemoryStream ms = new();
        string plain = await SerializationOperations.ToJsonAsync(mockClass);
        Console.WriteLine(plain);
        System.IO.StreamWriter sw = new(ms) { AutoFlush = true };
        await sw.WriteAsync(plain);
        ms.Position = 0;

        // From Json (stream)
        var assert = await SerializationOperations.FromJsonAsync<Resources.Mocks.Classes.MockClass>(ms);
        assert.Id.Should().Be(2);
        assert.Name.Should().Be("Miguel");
    }

}

