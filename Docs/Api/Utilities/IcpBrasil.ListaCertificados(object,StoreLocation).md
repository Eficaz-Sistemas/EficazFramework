#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Security.Credential](EficazFrameworkUtilities.md#EficazFramework.Security.Credential 'EficazFramework.Security.Credential').[IcpBrasil](IcpBrasil.md 'EficazFramework.Security.Credential.IcpBrasil')

## IcpBrasil.ListaCertificados(object, StoreLocation) Method

Obtém a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil.

```csharp
public static System.Collections.Generic.List<EficazFramework.Security.Credential.IcpBrasil> ListaCertificados(object filtro, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation);
```
#### Parameters

<a name='EficazFramework.Security.Credential.IcpBrasil.ListaCertificados(object,System.Security.Cryptography.X509Certificates.StoreLocation).filtro'></a>

`filtro` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Especifica algum critério para filtragem. Opcional.

<a name='EficazFramework.Security.Credential.IcpBrasil.ListaCertificados(object,System.Security.Cryptography.X509Certificates.StoreLocation).storeLocation'></a>

`storeLocation` [System.Security.Cryptography.X509Certificates.StoreLocation](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.StoreLocation 'System.Security.Cryptography.X509Certificates.StoreLocation')

Determina se será pesquisado no Rpositório Global ou no Repositório do Usuário Logado.

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[IcpBrasil](IcpBrasil.md 'EficazFramework.Security.Credential.IcpBrasil')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

### Remarks