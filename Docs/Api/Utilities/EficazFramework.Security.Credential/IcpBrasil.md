#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Security.Credential](EficazFrameworkUtilities.md#EficazFramework.Security.Credential 'EficazFramework.Security.Credential')

## IcpBrasil Class

```csharp
public class IcpBrasil : System.Security.Cryptography.X509Certificates.X509Certificate2
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Security.Cryptography.X509Certificates.X509Certificate](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate 'System.Security.Cryptography.X509Certificates.X509Certificate') &#129106; [System.Security.Cryptography.X509Certificates.X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2 'System.Security.Cryptography.X509Certificates.X509Certificate2') &#129106; IcpBrasil
### Methods

<a name='EficazFramework.Security.Credential.IcpBrasil.FormatData(System.Security.Cryptography.X509Certificates.X509Certificate2Collection)'></a>

## IcpBrasil.FormatData(X509Certificate2Collection) Method

Formata os dados utilizando-se da classe Helpers.CertficatesData, tornando possível utilizar-se de DataBinding

```csharp
private static System.Collections.Generic.List<EficazFramework.Security.Credential.IcpBrasil> FormatData(System.Security.Cryptography.X509Certificates.X509Certificate2Collection certificados);
```
#### Parameters

<a name='EficazFramework.Security.Credential.IcpBrasil.FormatData(System.Security.Cryptography.X509Certificates.X509Certificate2Collection).certificados'></a>

`certificados` [System.Security.Cryptography.X509Certificates.X509Certificate2Collection](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2Collection 'System.Security.Cryptography.X509Certificates.X509Certificate2Collection')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[IcpBrasil](EficazFramework.Security.Credential/IcpBrasil.md 'EficazFramework.Security.Credential.IcpBrasil')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

### Remarks

<a name='EficazFramework.Security.Credential.IcpBrasil.GetCertificatesStoreInternal(object,System.Security.Cryptography.X509Certificates.StoreLocation)'></a>

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

<a name='EficazFramework.Security.Credential.IcpBrasil.ListaCertificados(object,System.Security.Cryptography.X509Certificates.StoreLocation)'></a>

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
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[IcpBrasil](EficazFramework.Security.Credential/IcpBrasil.md 'EficazFramework.Security.Credential.IcpBrasil')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

### Remarks

<a name='EficazFramework.Security.Credential.IcpBrasil.ListaCertificadosAsync(object,System.Security.Cryptography.X509Certificates.StoreLocation)'></a>

## IcpBrasil.ListaCertificadosAsync(object, StoreLocation) Method

Obtém de forma assíncrona a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil.

```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.List<EficazFramework.Security.Credential.IcpBrasil>> ListaCertificadosAsync(object filtro, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation);
```
#### Parameters

<a name='EficazFramework.Security.Credential.IcpBrasil.ListaCertificadosAsync(object,System.Security.Cryptography.X509Certificates.StoreLocation).filtro'></a>

`filtro` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Especifica algum critério para filtragem. Opcional.

<a name='EficazFramework.Security.Credential.IcpBrasil.ListaCertificadosAsync(object,System.Security.Cryptography.X509Certificates.StoreLocation).storeLocation'></a>

`storeLocation` [System.Security.Cryptography.X509Certificates.StoreLocation](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.StoreLocation 'System.Security.Cryptography.X509Certificates.StoreLocation')

Determina se será pesquisado no Repositório Global ou no Repositório do Usuário Logado.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[IcpBrasil](EficazFramework.Security.Credential/IcpBrasil.md 'EficazFramework.Security.Credential.IcpBrasil')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

### Remarks