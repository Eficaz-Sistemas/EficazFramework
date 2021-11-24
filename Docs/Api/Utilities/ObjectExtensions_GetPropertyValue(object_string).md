#### [EficazFramework.Utilities](EficazFramework_Utilities.md 'EficazFramework.Utilities')
### [EficazFramework.Extensions](EficazFramework_Utilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[ObjectExtensions](ObjectExtensions.md 'EficazFramework.Extensions.ObjectExtensions')
## ObjectExtensions.GetPropertyValue(object, string) Method
Obtém o valor via Reflection de uma propriedade de uma instâcia de objeto, considerando também caminhos complexos  
semelhante ao processo de DataBinding do WPF.  
```csharp
public static object GetPropertyValue(this object instance, string path);
```
#### Parameters
<a name='EficazFramework_Extensions_ObjectExtensions_GetPropertyValue(object_string)_instance'></a>
`instance` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
A instancia de objeto a ser analisada para se obter valores
  
<a name='EficazFramework_Extensions_ObjectExtensions_GetPropertyValue(object_string)_path'></a>
`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
O nome da propriedade na qual se deseja obter o valor.
  
#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
Object
### Remarks
Para caminhos completox, separe cada membro por ponto. Ex: Endereco.UF: Obtém a UF, da instância de endereço, que por sua vez é  
            uma propriedade de uma entidade de nível superior, como por exemplo Empresa.
