using System.Threading.Tasks;

namespace EficazFramework.Serialization;

public class SerializationOperations
{

    // ### FROM XML
    public static T FromXml<T>(System.IO.Stream source)
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(source);
    }

    public static T FromXmlAsync<T>(System.IO.Stream source)
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(source);
    }

    // ### TO XML

    public static void ToXml<T>(T source, System.IO.Stream target)
    {
        var settings = new System.Xml.XmlWriterSettings() { Indent = true };
        ToXml(source, target, settings);
    }

    public static void ToXml<T>(T source, System.IO.Stream target, System.Xml.XmlWriterSettings settings)
    {
        var writer = System.Xml.XmlWriter.Create(target, settings);
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        serializer.Serialize(writer, source);
        writer.Dispose();
    }

    public static void ToXml<T>(T source, string targetpath)
    {
        var settings = new System.Xml.XmlWriterSettings() { Indent = true };
        ToXml(source, targetpath, settings);
    }

    public static void ToXml<T>(T source, string targetpath, System.Xml.XmlWriterSettings settings)
    {
        var file = new System.IO.FileStream(targetpath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
        ToXml(source, file, settings);
        file.Close();
        file.Dispose();
    }

    public static async Task ToXmlAsync<T>(T source, System.IO.Stream target)
    {
        var settings = new System.Xml.XmlWriterSettings() { Indent = true };
        await ToXmlAsync(source, target, settings);
    }

    public static async Task ToXmlAsync<T>(T source, System.IO.Stream target, System.Xml.XmlWriterSettings settings)
    {
        var writer = System.Xml.XmlWriter.Create(target, settings);
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        await Task.Run(() =>
        {
            serializer.Serialize(writer, source);
            return true;
        });
        writer.Dispose();
    }

    public static async Task ToXmlAsync<T>(T source, string targetpath)
    {
        var settings = new System.Xml.XmlWriterSettings() { Indent = true };
        var file = new System.IO.FileStream(targetpath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
        await ToXmlAsync(source, file, settings);
        file.Close();
        await file.DisposeAsync();
    }

    public static async Task ToXmlAsync<T>(T source, string targetpath, System.Xml.XmlWriterSettings settings)
    {
        var file = new System.IO.FileStream(targetpath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
        await ToXmlAsync(source, file, settings);
        file.Close();
        await file.DisposeAsync();
    }

    public static async Task ToXmlFileAsync<T>(T source, string targetpath, System.Xml.XmlWriterSettings settings)
    {
        var file = new System.IO.FileStream(targetpath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
        await ToXmlAsync(source, file, settings);
        file.Close();
        await file.DisposeAsync();
    }

    // ### FROM JSON

    public static readonly System.Text.Json.JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static T FromJson<T>(string source)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(source, JsonSerializerOptions);
    }

    public static T FromJsonFile<T>(string sourcePath)
    {
        string filecontent = System.IO.File.ReadAllText(sourcePath);
        return FromJson<T>(filecontent);
    }

    public static async Task<T> FromJsonAsync<T>(string source)
    {
        T result = default;
        using (var memory = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(source)))
        {
            result = await FromJsonAsync<T>(memory);
            memory.Close();
            await memory.DisposeAsync();
        }

        return result;
    }

    public static async Task<T> FromJsonAsync<T>(System.IO.Stream source)
    {
        return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(source, JsonSerializerOptions); ;
    }

    public static async Task<T> FromJsonFileAsync<T>(string sourcePath)
    {
        string filecontent = await System.IO.File.ReadAllTextAsync(sourcePath, System.Text.Encoding.UTF8);
        return await FromJsonAsync<T>(filecontent);
    }

    // ### TO JSON

    public static string ToJson<T>(T source)
    {
        return System.Text.Json.JsonSerializer.Serialize(source, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
    }

    public static void ToJsonFile<T>(T source, string targetPath)
    {
        var file = new System.IO.FileStream(targetPath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
        string datastring = ToJson(source);
        file.Write(System.Text.Encoding.UTF8.GetBytes(datastring));
        file.Close();
        file.Dispose();
    }

    public static async Task<string> ToJsonAsync<T>(T source)
    {
        string data;
        using (var memory = new System.IO.MemoryStream())
        {
            await System.Text.Json.JsonSerializer.SerializeAsync(memory, source, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            memory.Position = 0;
            data = System.Text.Encoding.UTF8.GetString(memory.ToArray());
            memory.Close();
            await memory.DisposeAsync();
        }

        return data;
    }

    public static async Task ToJsonFileAsync<T>(T source, string targetPath)
    {
        var file = new System.IO.FileStream(targetPath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
        await System.Text.Json.JsonSerializer.SerializeAsync(file, source, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        file.Close();
        await file.DisposeAsync();
    }
}
