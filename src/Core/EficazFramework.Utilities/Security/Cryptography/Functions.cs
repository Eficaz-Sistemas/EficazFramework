﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Security.Cryptography;

public class Functions
{
    private static readonly MD5 _md5 = MD5.Create();

    public static string Encript(string text, string key)
    {
        return Encript(text, _md5.ComputeHash(Encoding.Unicode.GetBytes(key)));
    }

    private static string Encript(string text, byte[] key)
    {
        var input = Encoding.UTF8.GetBytes(text);
        var output = CreateDes(key).CreateEncryptor().TransformFinalBlock(input, 0, input.Length);
        return Convert.ToBase64String(output);
    }

    public static string Decript(string text, string key)
    {
        return Decript(text, MD5.HashData(Encoding.Unicode.GetBytes(key)));
    }

#if NET7_0_OR_GREATER
    public static async Task<string> DecriptAsync(string text, string key)
    {
        return Decript(text, await MD5.HashDataAsync(new System.IO.MemoryStream(Encoding.Unicode.GetBytes(key))));
    }
#endif

    private static string Decript(string text, byte[] key)
    {
        var input = Convert.FromBase64String(text);
        var output = CreateDes(key).CreateDecryptor().TransformFinalBlock(input, 0, input.Length);
        return (Encoding.UTF8.GetString(output) ?? "").Replace("\u0000", "");
    }

    private static TripleDES CreateDes(byte[] key)
    {
        TripleDES des = TripleDES.Create();
        des.Mode = CipherMode.ECB;
        des.Padding = PaddingMode.Zeros;
        des.Key = key;
        des.IV = new byte[des.BlockSize / 8];
        return des;
    }
}