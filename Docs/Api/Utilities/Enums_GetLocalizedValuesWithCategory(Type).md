#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[Enums](Enums.md 'EficazFramework.Extensions.Enums')
## Enums.GetLocalizedValuesWithCategory(Type) Method
Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de enumType  
```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.GroupedEnumMember> GetLocalizedValuesWithCategory(this System.Type EnumType);
```
#### Parameters
<a name='EficazFramework_Extensions_Enums_GetLocalizedValuesWithCategory(System_Type)_EnumType'></a>
`EnumType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.GroupedEnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.GroupedEnumMember 'EficazFramework.Extensions.GroupedEnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember