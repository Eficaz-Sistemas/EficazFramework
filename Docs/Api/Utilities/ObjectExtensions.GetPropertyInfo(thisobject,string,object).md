#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[ObjectExtensions](ObjectExtensions.md 'EficazFramework.Extensions.ObjectExtensions')

## ObjectExtensions.GetPropertyInfo(this object, string, object) Method

Obtém via Reflection as definições de uma propriedade de instância de objeto, considerando também caminhos complexos  
semelhante ao processo de DataBinding do WPF.

```csharp
public static System.Reflection.PropertyInfo GetPropertyInfo(this object instance, string path, ref object out_instance=null);
```
#### Parameters

<a name='EficazFramework.Extensions.ObjectExtensions.GetPropertyInfo(thisobject,string,object).instance'></a>

`instance` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

A instancia de objeto a ser analisada para se obter valores

<a name='EficazFramework.Extensions.ObjectExtensions.GetPropertyInfo(thisobject,string,object).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O nome da propriedade na qual se deseja obter o valor.

<a name='EficazFramework.Extensions.ObjectExtensions.GetPropertyInfo(thisobject,string,object).out_instance'></a>

`out_instance` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.Reflection.PropertyInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.PropertyInfo 'System.Reflection.PropertyInfo')  
Object

### Remarks
Para caminhos completox, separe cada membro por ponto. Ex: Endereco.UF: Obtém a UF, da instância de endereço, que por sua vez é  
            uma propriedade de uma entidade de nível superior, como por exemplo Empresa.