#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[Enums](Enums.md 'EficazFramework.Extensions.Enums')
## Enums.GetLocalizedValues&lt;TEnum&gt;(Type) Method
Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de TEnum  
```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.EnumMember> GetLocalizedValues<TEnum>(System.Type resourceType);
```
#### Type parameters
<a name='EficazFramework_Extensions_Enums_GetLocalizedValues_TEnum_(System_Type)_TEnum'></a>
`TEnum`  
  
#### Parameters
<a name='EficazFramework_Extensions_Enums_GetLocalizedValues_TEnum_(System_Type)_resourceType'></a>
`resourceType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.EnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.EnumMember 'EficazFramework.Extensions.EnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember