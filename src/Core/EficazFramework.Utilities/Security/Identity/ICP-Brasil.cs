// ---------------------------------------------------------------------------------------------------------------------
// Biblioteca NF-eletrônica.
// ---------------------------------------------------------------------------------------------------------------------
// 
// Condições de uso
// 
// Este material pode ser copiado, distribuído, exibido e executado, bem como utilizado para criar obras derivadas,
// sob licença Creative Commons Attribution (http://creativecommons.org/licenses/by/2.5/br/), com a citação da fonte
// e o devido crédito.
// 
// Acesse hhtpNF-eletronica.comblog para obter obter mais Informações Técnicas do Projeto Nota Fiscal eletônica.
// 
// (c) 2008 - NF-eletronica.com
// ---------------------------------------------------------------------------------------------------------------------


// ---------------------------------------------------------------------------------------------------------------------
// 
// Traduzido para VB.NET e adaptado à necessidades da EficazFramework.SPED por Eficaz Sistemas de Gestão e Inteligência Tributária Ltda.
// Médoto traduzido: AssinarXML()
// Cópia / Modificações / Distribuições proibidas. Código privado de propriedade da Eficaz Sistemas de Gestão e Inteligência Tributária Ltda.
// Caso deseje obter o código, baixe a versão aberta em http://NF-eletronica.com/blog
// 
// Daniel Lucindo Basílio
// Frankson Malta
// Henrique Clausing Cunha
// 
// ---------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualBasic.CompilerServices;
using EficazFramework.Extensions;

namespace EficazFramework.Security.Credential;

public class IcpBrasil : X509Certificate2
{
    #region Constructor

    public IcpBrasil(string filename, string password) : base(filename, password)
    {
        var data = Subject.Split(",");
        var temp = data[0].Split(":");
        if (temp.Length >= 1)
            Titular = temp[0].Replace("CN=", "");
        if (temp.Length >= 2)
            CNPJ_CPF = temp[1].ToString().FormatRFBDocument();
        if (data.Length >= 2)
            AutoridadeCertificadora = data[1].Replace("OU=Autenticado por ", "").Trim();
        if (data.Length >= 3)
            Tipo = data[2].Replace("OU=", "").Trim();
        DataEfetiva = Conversions.ToDate(GetEffectiveDateString());
        Validade = Conversions.ToDate(GetExpirationDateString());
        PrivateInstance = this;
    }

    public IcpBrasil(byte[] rawdata, X509Certificate2 instance, string password = null) : base(rawdata, password)
    {
        var data = Subject.Split(",");
        var temp = data[0].Split(":");
        if (temp.Length >= 1)
            Titular = temp[0].Replace("CN=", "");
        if (temp.Length >= 2)
            CNPJ_CPF = temp[1].ToString().FormatRFBDocument();
        if (data.Length >= 2)
            AutoridadeCertificadora = data[1].Replace("OU=Autenticado por ", "").Trim();
        if (data.Length >= 3)
            Tipo = data[2].Replace("OU=", "").Trim();
        DataEfetiva = Conversions.ToDate(GetEffectiveDateString());
        Validade = Conversions.ToDate(GetExpirationDateString());
        PrivateInstance = instance;
        // If instance IsNot Nothing Then Me.PrivateKey = instance.PrivateKey
    }


    #endregion

    #region Properties

    public string AutoridadeCertificadora { get; private set; }
    public string CNPJ_CPF { get; private set; }
    public DateTime? DataEfetiva { get; private set; }
    public string Tipo { get; private set; }
    public string Titular { get; private set; }
    public DateTime? Validade { get; private set; }
    public X509Certificate PrivateInstance { get; private set; }

    #endregion


    /// <summary>
    /// Obtém a lista de Certificados Digitais hospedadas no Repositório do Navegador.
    /// </summary>
    /// <param name="filter">Especifica algum critério para filtragem. Opcional.</param>
    /// <param name="storeLocation">Determina se será pesquisado no Repositório Global ou no Repositório do Usuário Logado.</param>
    /// <returns>List(Of String())</returns>
    /// <remarks></remarks>
    private static X509Certificate2Collection GetCertificatesStoreInternal(object filter, StoreLocation storeLocation)
    {
        X509Certificate2Collection certificates;
        var store = new X509Store("MY", storeLocation);
        store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

        // certificates = store.Certificates.Find(X509FindType.FindByTimeValid, Now.Date, True)
        certificates = store.Certificates; // .Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, True)
                                           // certificates = certificates.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, True)
        if (filter != null)
        {
            certificates = store.Certificates.Find(X509FindType.FindBySubjectName, filter, true);
        }

        store.Close();
        return certificates;
    }

    /// <summary>
    /// Formata os dados utilizando-se da classe Helpers.CertficatesData, tornando possível utilizar-se de DataBinding
    /// </summary>
    /// <param name="certificados"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    private static List<IcpBrasil> FormatData(X509Certificate2Collection certificados)
    {
        var final = new List<IcpBrasil>();
        foreach (X509Certificate2 cert in certificados)
        {
            if (!cert.Subject.ToLower().Contains("icp-brasil"))
                continue;
            final.Add(new IcpBrasil(cert.RawData, cert));
        }

        return final.OrderBy(f => f.Titular).ToList();
    }

    /// <summary>
    /// Obtém a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil.
    /// </summary>
    /// <param name="filtro">Especifica algum critério para filtragem. Opcional.</param>
    /// <param name="storeLocation">Determina se será pesquisado no Rpositório Global ou no Repositório do Usuário Logado.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static List<IcpBrasil> ListaCertificados(object filtro, StoreLocation storeLocation)
    {
        var list = GetCertificatesStoreInternal(filtro, storeLocation);
        return FormatData(list);
    }

    /// <summary>
    /// Obtém de forma assíncrona a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil.
    /// </summary>
    /// <param name="filtro">Especifica algum critério para filtragem. Opcional.</param>
    /// <param name="storeLocation">Determina se será pesquisado no Repositório Global ou no Repositório do Usuário Logado.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static async Task<List<IcpBrasil>> ListaCertificadosAsync(object filtro, StoreLocation storeLocation)
    {
        var list = await Task.Run(() => GetCertificatesStoreInternal(filtro, storeLocation));
        return FormatData(list);
    }

    public void SignXml(System.Xml.XmlDocument xml, string tag, string id, bool signAsSHA256 = false, bool emptyURI = false)
    {

        XML.XMLOperations.SignXml(xml, tag, id, (X509Certificate2)PrivateInstance, signAsSHA256, emptyURI);
    }

    public void SignXml(XDocument xml, string tag, string id, bool signAsSHA256 = false, bool emptyURI = false)
    {
        XML.XMLOperations.SignXml(ref xml, tag, id, (X509Certificate2)PrivateInstance, signAsSHA256, emptyURI);
    }

    public override string ToString()
    {
        return string.Format("{0} | CNPJ / CPF: {1} | Validade: {2} a {3}", Titular, CNPJ_CPF, DataEfetiva, Validade);
    }

}
