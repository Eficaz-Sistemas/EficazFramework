#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[ObjectExtensions](EficazFramework.Extensions/ObjectExtensions.md 'EficazFramework.Extensions.ObjectExtensions')

## ObjectExtensions.GetPropertyValue(this object, string) Method

Obtém o valor via Reflection de uma propriedade de uma instâcia de objeto, considerando também caminhos complexos  
semelhante ao processo de DataBinding do WPF.

```csharp
public static object GetPropertyValue(this object instance, string path);
```
#### Parameters

<a name='EficazFramework.Extensions.ObjectExtensions.GetPropertyValue(thisobject,string).instance'></a>

`instance` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

A instancia de objeto a ser analisada para se obter valores

<a name='EficazFramework.Extensions.ObjectExtensions.GetPropertyValue(thisobject,string).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O nome da propriedade na qual se deseja obter o valor.

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
Object

### Remarks
Para caminhos completox, separe cada membro por ponto. Ex: Endereco.UF: Obtém a UF, da instância de endereço, que por sua vez é  
            uma propriedade de uma entidade de nível superior, como por exemplo Empresa.