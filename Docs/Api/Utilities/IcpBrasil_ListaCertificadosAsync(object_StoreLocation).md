#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Security.Credential](EficazFrameworkUtilities.md#EficazFramework_Security_Credential 'EficazFramework.Security.Credential').[IcpBrasil](IcpBrasil.md 'EficazFramework.Security.Credential.IcpBrasil')
## IcpBrasil.ListaCertificadosAsync(object, StoreLocation) Method
Obtém de forma assíncrona a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil.  
```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.List<EficazFramework.Security.Credential.IcpBrasil>> ListaCertificadosAsync(object filtro, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation);
```
#### Parameters
<a name='EficazFramework_Security_Credential_IcpBrasil_ListaCertificadosAsync(object_System_Security_Cryptography_X509Certificates_StoreLocation)_filtro'></a>
`filtro` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
Especifica algum critério para filtragem. Opcional.
  
<a name='EficazFramework_Security_Credential_IcpBrasil_ListaCertificadosAsync(object_System_Security_Cryptography_X509Certificates_StoreLocation)_storeLocation'></a>
`storeLocation` [System.Security.Cryptography.X509Certificates.StoreLocation](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.StoreLocation 'System.Security.Cryptography.X509Certificates.StoreLocation')  
Determina se será pesquisado no Repositório Global ou no Repositório do Usuário Logado.
  
#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[IcpBrasil](IcpBrasil.md 'EficazFramework.Security.Credential.IcpBrasil')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
### Remarks
