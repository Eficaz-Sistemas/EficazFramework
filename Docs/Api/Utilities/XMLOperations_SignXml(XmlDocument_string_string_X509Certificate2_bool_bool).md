#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.XML](EficazFrameworkUtilities.md#EficazFramework_XML 'EficazFramework.XML').[XMLOperations](XMLOperations.md 'EficazFramework.XML.XMLOperations')
## XMLOperations.SignXml(XmlDocument, string, string, X509Certificate2, bool, bool) Method
Realiza a assinatura digital de um documento XML.  
```csharp
public static void SignXml(System.Xml.XmlDocument xml, string tag, string idTag, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate, bool signAsSHA256=false, bool emptyURI=false);
```
#### Parameters
<a name='EficazFramework_XML_XMLOperations_SignXml(System_Xml_XmlDocument_string_string_System_Security_Cryptography_X509Certificates_X509Certificate2_bool_bool)_xml'></a>
`xml` [System.Xml.XmlDocument](https://docs.microsoft.com/en-us/dotnet/api/System.Xml.XmlDocument 'System.Xml.XmlDocument')  
O XMLDocument a ser assinado.
  
<a name='EficazFramework_XML_XMLOperations_SignXml(System_Xml_XmlDocument_string_string_System_Security_Cryptography_X509Certificates_X509Certificate2_bool_bool)_tag'></a>
`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A tag para localização do ponto de assinatura.
  
<a name='EficazFramework_XML_XMLOperations_SignXml(System_Xml_XmlDocument_string_string_System_Security_Cryptography_X509Certificates_X509Certificate2_bool_bool)_idTag'></a>
`idTag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
A tag com a ID a ser assinada.
  
<a name='EficazFramework_XML_XMLOperations_SignXml(System_Xml_XmlDocument_string_string_System_Security_Cryptography_X509Certificates_X509Certificate2_bool_bool)_certificate'></a>
`certificate` [System.Security.Cryptography.X509Certificates.X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2 'System.Security.Cryptography.X509Certificates.X509Certificate2')  
  
<a name='EficazFramework_XML_XMLOperations_SignXml(System_Xml_XmlDocument_string_string_System_Security_Cryptography_X509Certificates_X509Certificate2_bool_bool)_signAsSHA256'></a>
`signAsSHA256` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
<a name='EficazFramework_XML_XMLOperations_SignXml(System_Xml_XmlDocument_string_string_System_Security_Cryptography_X509Certificates_X509Certificate2_bool_bool)_emptyURI'></a>
`emptyURI` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
### Remarks
