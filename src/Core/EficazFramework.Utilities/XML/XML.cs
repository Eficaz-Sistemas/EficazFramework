using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace EficazFramework.XML;

/// <exclude/>
public class XMLOperations
{

    /// <summary>
    /// Realiza a assinatura digital de um documento XML.
    /// </summary>
    /// <param name="xml">O XMLDocument a ser assinado.</param>
    /// <param name="tag">A tag para localização do ponto de assinatura.</param>
    /// <param name="idTag">A tag com a ID a ser assinada.</param>
    /// <remarks></remarks>
    public static void SignXml(XmlDocument xml, string tag, string idTag, X509Certificate2 certificate, bool signAsSHA256 = false, bool emptyURI = false)
    {
        // ## Realiza ajustes necessários no XMLDocument e confere se a URI informada é válida
        // If xml.PreserveWhitespace = True Then
        // xml.PreserveWhitespace = False
        // End If
        if (certificate is null)
            throw new ArgumentNullException(EficazFramework.Resources.Strings.XML.Sign_NullX509Certificate);
        var tags = xml.GetElementsByTagName(tag);
        int count = tags.Count;
      
        if (count == 0)
            throw new ArgumentException(string.Format(EficazFramework.Resources.Strings.XML.Sign_TagNotFound, tag));
        else if (count > 1)
            throw new ArgumentException(string.Format(EficazFramework.Resources.Strings.XML.Sign_TagNonUnique, tag));

        // ## Solicita as credenciais do certificado
        var sxml = new SignedXml(xml)
        {
            SigningKey = certificate.GetRSAPrivateKey()
        };
        if (signAsSHA256 == true)
            sxml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";

        // ## Faz umas coisas que eu não entendi
        var @ref = new Reference();
        if (emptyURI == false)
            @ref.Uri = "#" + xml.GetElementsByTagName(idTag).Item(0)?.Attributes?.Cast<XmlNode>()?.Where(att => att.Name.ToLower() == "id").First().InnerText;
        else
            @ref.Uri = "";
        @ref.AddTransform(new XmlDsigEnvelopedSignatureTransform());
        @ref.AddTransform(new XmlDsigC14NTransform());
        if (signAsSHA256 == true)
            @ref.DigestMethod = "http://www.w3.org/2001/04/xmlenc#sha256";
        sxml.AddReference(@ref);

        // ## Inicia a assinatura
        var ki = new KeyInfo();
        ki.AddClause(new KeyInfoX509Data(certificate));
        sxml.KeyInfo = ki;
        sxml.ComputeSignature();

        // ## Obtém a representação gráfica da assinatura e a salva em um objeto XMLElement
        Debug.WriteLine(string.Format("Signature: {0}", sxml.CheckSignature()));
        var xmle = sxml.GetXml();

        // ## Adiciona o XMLElement assinado ao XMLDocument e faz um clonning para evitar algum problema que eu não entendi
        tags[0]!.AppendChild(xml.ImportNode(xmle, true));

        // ## Trace Debug
        var stringWriter = new System.IO.StringWriter();
        var xmlWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented, Indentation = 2 };
        xml.WriteTo(xmlWriter);
        string result_str = stringWriter.ToString();
        Debug.WriteLine(result_str);
    }

    /// <summary>
    /// Realiza a assinatura digital de um documento XML.
    /// </summary>
    /// <param name="xdoc">O XMLDocument a ser assinado.</param>
    /// <param name="tag">A tag para localização do ponto de assinatura.</param>
    /// <param name="idTag">A tag com a ID a ser assinada.</param>
    /// <remarks></remarks>
    public static void SignXml(ref XDocument xdoc, string tag, string idTag, X509Certificate2 certificate, bool signAsSHA256 = false, bool emptyURI = false)
    {
        var xml = ToXmlDocument(xdoc);
        SignXml(xml, tag, idTag, certificate, signAsSHA256, emptyURI);
        xdoc = ToXDocument(xml);
    }

    /// <summary>
    /// Converte uma instância de System.Xml.XmlElement para System.Xml.Linq.XElement
    /// </summary>
    public static XElement ToXElement(XmlElement source)
    {
        return XElement.Parse(source.OuterXml);
    }

    /// <summary>
    /// Converte uma instância de System.Xml.Linq.XElement para System.Xml.XmlElement
    /// </summary>
    public static XmlElement ToXmlElement([NotNull] XElement source)
    {
        if (source is null)
            throw new NullReferenceException();
        var tmp_doc = new XmlDocument();
        tmp_doc.Load(source.CreateReader());
        var result = tmp_doc.DocumentElement;
        return result;
    }

    /// <summary>
    /// Converte uma instância de System.Xml.Linq.XDocument para System.Xml.XmlDocument
    /// </summary>
    public static XmlDocument ToXmlDocument(XDocument xDocument)
    {
        var xmlDocument = new XmlDocument();
        using (var xmlReader = xDocument.CreateReader())
        {
            xmlDocument.Load(xmlReader);
        }

        return xmlDocument;
    }

    /// <summary>
    /// Converte uma instância de System.Xml.XmlDocument para System.Xml.Linq.XDocument
    /// </summary>
    public static XDocument ToXDocument(XmlDocument xmlDocument)
    {
        var nodeReader = new XmlNodeReader(xmlDocument);
        nodeReader.MoveToContent();
        return XDocument.Load(nodeReader);
    }

    /// <summary>
    /// Returna uma instância de System.Xml.XmlDocument a partir de arquivo físico.
    /// </summary>s
    public static XmlDocument ToXmlDocument(string sourcePath)
    {
        var result = new XmlDocument();
        string filecontent = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.UTF8);
        result.LoadXml(filecontent);
        return result;
    }

    /// <summary>
    /// Returna uma instância de System.Xml.XmlDocument a partir de arquivo físico.
    /// </summary>s
    public static async Task<XmlDocument> ToXmlDocumentAsync(string sourcePath)
    {
        var result = new XmlDocument();
        string filecontent = await System.IO.File.ReadAllTextAsync(sourcePath, System.Text.Encoding.UTF8);
        result.LoadXml(filecontent);
        return result;
    }

}
