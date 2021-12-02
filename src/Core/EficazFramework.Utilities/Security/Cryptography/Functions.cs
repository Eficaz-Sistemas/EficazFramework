using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace EficazFramework.Security.Cryptography;

public class Functions
{

    private static readonly TripleDES _des = TripleDES.Create();
    private static readonly MD5 _md5 = MD5.Create();
    private static readonly UTF8Encoding _utf8 = new();

    public static string Encript(string text, string parameter1)
    {
        return Encript(text, _md5.ComputeHash(Encoding.Unicode.GetBytes(parameter1)));
    }

    private static string Encript(string text, byte[] key)
    {
        try
        {
            var input = _utf8.GetBytes(text);
            _des.Key = key;
            _des.GenerateIV();
            var output = Transform(input, _des.CreateEncryptor());
            return Convert.ToBase64String(output);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return "bad data";
        }
    }

    public static string Decript(string text, string parameter1)
    {
        var md5 = MD5.Create();
        return Decript(text, md5.ComputeHash(Encoding.Unicode.GetBytes(parameter1)));
    }

    private static string Decript(string text, byte[] key)
    {
        try
        {
            var input = Convert.FromBase64String(text);
            _des.Key = key;
            _des.GenerateIV();
            var output = Transform(input, _des.CreateDecryptor());
            return _utf8.GetString(output);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return "bad data";
        }
    }

    private static byte[] Transform(byte[] input, ICryptoTransform CryptoTransform)
    {
        // create the necessary streams
        var memStream = new MemoryStream();
        var cryptStream = new CryptoStream(memStream, CryptoTransform, CryptoStreamMode.Write);

        // transform the bytes as requested
        cryptStream.Write(input, 0, input.Length);
        byte[] result = memStream.ToArray();

        // close and release the streams
        memStream.Close();

        // hand back the encrypted buffer
        return result;
    }

    public static string ToUrlSlug(string value)
    {
        value = value.ToLowerInvariant();
        var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
        value = Encoding.ASCII.GetString(bytes);
        value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);
        value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);
        value = value.Trim('-', '_');
        value = Regex.Replace(value, "([-_]){2,}", "$1", RegexOptions.Compiled);
        return value;
    }

    public static string ComputeMD5Hash(string value)
    {
        var bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
        StringBuilder sBuilder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            sBuilder.Append(bytes[i].ToString("x2"));
        }
        string result = sBuilder.ToString();
        return result;
    }

    public static string ComputeSHA256Hash(string value)
    {
        var bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value));
        StringBuilder sBuilder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            sBuilder.Append(bytes[i].ToString("x2"));
        }
        string result = sBuilder.ToString();
        return result;
    }
}