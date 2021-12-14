#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.XML](EficazFrameworkData.md#EficazFramework.XML 'EficazFramework.XML')

## XMLOperations Class

```csharp
public class XMLOperations
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; XMLOperations
### Methods

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool)'></a>

## XMLOperations.SignXml(XDocument, string, string, X509Certificate2, bool, bool) Method

Realiza a assinatura digital de um documento XML.

```csharp
public static void SignXml(ref System.Xml.Linq.XDocument xdoc, string tag, string idTag, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate, bool signAsSHA256=false, bool emptyURI=false);
```
#### Parameters

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).xdoc'></a>

`xdoc` [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

O XMLDocument a ser assinado.

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).tag'></a>

`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A tag para localização do ponto de assinatura.

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).idTag'></a>

`idTag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A tag com a ID a ser assinada.

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).certificate'></a>

`certificate` [System.Security.Cryptography.X509Certificates.X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2 'System.Security.Cryptography.X509Certificates.X509Certificate2')

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).signAsSHA256'></a>

`signAsSHA256` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.Linq.XDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).emptyURI'></a>

`emptyURI` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### Remarks

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.XmlDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool)'></a>

## XMLOperations.SignXml(XmlDocument, string, string, X509Certificate2, bool, bool) Method

Realiza a assinatura digital de um documento XML.

```csharp
public static void SignXml(System.Xml.XmlDocument xml, string tag, string idTag, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate, bool signAsSHA256=false, bool emptyURI=false);
```
#### Parameters

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.XmlDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).xml'></a>

`xml` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

O XMLDocument a ser assinado.

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.XmlDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).tag'></a>

`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A tag para localização do ponto de assinatura.

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.XmlDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).idTag'></a>

`idTag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A tag com a ID a ser assinada.

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.XmlDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).certificate'></a>

`certificate` [System.Security.Cryptography.X509Certificates.X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2 'System.Security.Cryptography.X509Certificates.X509Certificate2')

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.XmlDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).signAsSHA256'></a>

`signAsSHA256` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.XML.XMLOperations.SignXml(System.Xml.XmlDocument,string,string,System.Security.Cryptography.X509Certificates.X509Certificate2,bool,bool).emptyURI'></a>

`emptyURI` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### Remarks

<a name='EficazFramework.XML.XMLOperations.ToXDocument(System.Xml.XmlDocument)'></a>

## XMLOperations.ToXDocument(XmlDocument) Method

Converte uma instância de System.Xml.XmlDocument para System.Xml.Linq.XDocument

```csharp
public static System.Xml.Linq.XDocument ToXDocument(System.Xml.XmlDocument xmlDocument);
```
#### Parameters

<a name='EficazFramework.XML.XMLOperations.ToXDocument(System.Xml.XmlDocument).xmlDocument'></a>

`xmlDocument` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

#### Returns
[System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

<a name='EficazFramework.XML.XMLOperations.ToXElement(System.Xml.XmlElement)'></a>

## XMLOperations.ToXElement(XmlElement) Method

Converte uma instância de System.Xml.XmlElement para System.Xml.Linq.XElement

```csharp
public static System.Xml.Linq.XElement ToXElement(System.Xml.XmlElement source);
```
#### Parameters

<a name='EficazFramework.XML.XMLOperations.ToXElement(System.Xml.XmlElement).source'></a>

`source` [System.Xml.XmlElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlElement 'System.Xml.XmlElement')

#### Returns
[System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

<a name='EficazFramework.XML.XMLOperations.ToXmlDocument(string)'></a>

## XMLOperations.ToXmlDocument(string) Method

Returna uma instância de System.Xml.XmlDocument a partir de arquivo físico.

```csharp
public static System.Xml.XmlDocument ToXmlDocument(string sourcePath);
```
#### Parameters

<a name='EficazFramework.XML.XMLOperations.ToXmlDocument(string).sourcePath'></a>

`sourcePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

<a name='EficazFramework.XML.XMLOperations.ToXmlDocument(System.Xml.Linq.XDocument)'></a>

## XMLOperations.ToXmlDocument(XDocument) Method

Converte uma instância de System.Xml.Linq.XDocument para System.Xml.XmlDocument

```csharp
public static System.Xml.XmlDocument ToXmlDocument(System.Xml.Linq.XDocument xDocument);
```
#### Parameters

<a name='EficazFramework.XML.XMLOperations.ToXmlDocument(System.Xml.Linq.XDocument).xDocument'></a>

`xDocument` [System.Xml.Linq.XDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XDocument 'System.Xml.Linq.XDocument')

#### Returns
[System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')

<a name='EficazFramework.XML.XMLOperations.ToXmlDocumentAsync(string)'></a>

## XMLOperations.ToXmlDocumentAsync(string) Method

Returna uma instância de System.Xml.XmlDocument a partir de arquivo físico.

```csharp
public static System.Threading.Tasks.Task<System.Xml.XmlDocument> ToXmlDocumentAsync(string sourcePath);
```
#### Parameters

<a name='EficazFramework.XML.XMLOperations.ToXmlDocumentAsync(string).sourcePath'></a>

`sourcePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.XML.XMLOperations.ToXmlElement(System.Xml.Linq.XElement)'></a>

## XMLOperations.ToXmlElement(XElement) Method

Converte uma instância de System.Xml.Linq.XElement para System.Xml.XmlElement

```csharp
public static System.Xml.XmlElement ToXmlElement(System.Xml.Linq.XElement source);
```
#### Parameters

<a name='EficazFramework.XML.XMLOperations.ToXmlElement(System.Xml.Linq.XElement).source'></a>

`source` [System.Xml.Linq.XElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.Linq.XElement 'System.Xml.Linq.XElement')

#### Returns
[System.Xml.XmlElement](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlElement 'System.Xml.XmlElement')