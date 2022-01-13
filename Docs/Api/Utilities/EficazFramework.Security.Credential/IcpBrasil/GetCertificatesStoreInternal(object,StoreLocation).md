#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Security.Credential](EficazFrameworkUtilities.md#EficazFramework.Security.Credential 'EficazFramework.Security.Credential').[IcpBrasil](EficazFramework.Security.Credential/IcpBrasil.md 'EficazFramework.Security.Credential.IcpBrasil')

## IcpBrasil.GetCertificatesStoreInternal(object, StoreLocation) Method

Obtém a lista de Certificados Digitais hospedadas no Repositório do Navegador.

```csharp
private static System.Security.Cryptography.X509Certificates.X509Certificate2Collection GetCertificatesStoreInternal(object filter, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation);
```
#### Parameters

<a name='EficazFramework.Security.Credential.IcpBrasil.GetCertificatesStoreInternal(object,System.Security.Cryptography.X509Certificates.StoreLocation).filter'></a>

`filter` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Especifica algum critério para filtragem. Opcional.

<a name='EficazFramework.Security.Credential.IcpBrasil.GetCertificatesStoreInternal(object,System.Security.Cryptography.X509Certificates.StoreLocation).storeLocation'></a>

`storeLocation` [System.Security.Cryptography.X509Certificates.StoreLocation](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.StoreLocation 'System.Security.Cryptography.X509Certificates.StoreLocation')

Determina se será pesquisado no Repositório Global ou no Repositório do Usuário Logado.

#### Returns
[System.Security.Cryptography.X509Certificates.X509Certificate2Collection](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2Collection 'System.Security.Cryptography.X509Certificates.X509Certificate2Collection')  
List(Of String())

### Remarks