#### [EficazFramework.Utilities](EficazFramework_Utilities.md 'EficazFramework.Utilities')
### [EficazFramework.Security.Credential](EficazFramework_Utilities.md#EficazFramework_Security_Credential 'EficazFramework.Security.Credential').[IcpBrasil](IcpBrasil.md 'EficazFramework.Security.Credential.IcpBrasil')
## IcpBrasil.GetCertificatesStoreInternal(object, StoreLocation) Method
Obtém a lista de Certificados Digitais hospedadas no Repositório do Navegador.  
```csharp
private static System.Security.Cryptography.X509Certificates.X509Certificate2Collection GetCertificatesStoreInternal(object filter, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation);
```
#### Parameters
<a name='EficazFramework_Security_Credential_IcpBrasil_GetCertificatesStoreInternal(object_System_Security_Cryptography_X509Certificates_StoreLocation)_filter'></a>
`filter` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
Especifica algum critério para filtragem. Opcional.
  
<a name='EficazFramework_Security_Credential_IcpBrasil_GetCertificatesStoreInternal(object_System_Security_Cryptography_X509Certificates_StoreLocation)_storeLocation'></a>
`storeLocation` [System.Security.Cryptography.X509Certificates.StoreLocation](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.StoreLocation 'System.Security.Cryptography.X509Certificates.StoreLocation')  
Determina se será pesquisado no Repositório Global ou no Repositório do Usuário Logado.
  
#### Returns
[System.Security.Cryptography.X509Certificates.X509Certificate2Collection](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2Collection 'System.Security.Cryptography.X509Certificates.X509Certificate2Collection')  
List(Of String())
### Remarks
