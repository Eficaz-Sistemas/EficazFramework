#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.XML](EficazFrameworkUtilities.md#EficazFramework.XML 'EficazFramework.XML').[XMLOperations](XMLOperations.md 'EficazFramework.XML.XMLOperations')

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