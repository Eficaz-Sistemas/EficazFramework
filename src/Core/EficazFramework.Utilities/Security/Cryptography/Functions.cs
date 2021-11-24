using Microsoft.VisualBasic.CompilerServices;
using System;
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

    public static string Encript(string text, string parameter1, string parameter2)
    {
        return Encript(text, _md5.ComputeHash(Encoding.Unicode.GetBytes(parameter1)), _md5.ComputeHash(Encoding.Unicode.GetBytes(parameter2)));
    }

    protected static string Encript(string text, byte[] key, byte[] iv)
    {
        try
        {
            var input = _utf8.GetBytes(text);
            var output = Transform(input, _des.CreateEncryptor(key, iv));
            return Convert.ToBase64String(output);
        }
        catch
        {
            // Dialogs.EfCrashDialog.ShowError("Erro 0x00000002", "bad data", "Informações corrompidas ou inválidas. Por favor entre em contato com o suporte.")
            return "bad data";
        }
    }

    public static string Decript(string text, string parameter1, string parameter2)
    {
        var md5 = MD5.Create();
        return Decript(text, md5.ComputeHash(Encoding.Unicode.GetBytes(parameter1)), md5.ComputeHash(Encoding.Unicode.GetBytes(parameter2)));
    }

    protected static string Decript(string text, byte[] key, byte[] iv)
    {
        try
        {
            var input = Convert.FromBase64String(text);
            var output = Transform(input, _des.CreateDecryptor(key, iv));
            return _utf8.GetString(output);
        }
        catch
        {
            // Dialogs.EfCrashDialog.ShowError("Erro 0x00000002", "bad data", "Informações corrompidas ou inválidas. Por favor entre em contato com o suporte.")
            return "bad data";
        }
    }

    protected static byte[] Transform(byte[] input, ICryptoTransform CryptoTransform)
    {
        // create the necessary streams
        var memStream = new MemoryStream();
        var cryptStream = new CryptoStream(memStream, CryptoTransform, CryptoStreamMode.Write);

        // transform the bytes as requested
        cryptStream.Write(input, 0, input.Length);
        cryptStream.FlushFinalBlock();

        // Read the memory stream and convert it back into byte array
        memStream.Position = 0;
        var result = new byte[Conversions.ToInteger(memStream.Length - 1) + 1];
        memStream.Read(result, 0, result.Length);

        // close and release the streams
        memStream.Close();
        cryptStream.Close();

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