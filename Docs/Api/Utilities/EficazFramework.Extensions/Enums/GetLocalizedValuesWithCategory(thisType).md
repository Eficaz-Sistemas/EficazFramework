#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[Enums](EficazFramework.Extensions/Enums.md 'EficazFramework.Extensions.Enums')

## Enums.GetLocalizedValuesWithCategory(this Type) Method

Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de enumType

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.GroupedEnumMember> GetLocalizedValuesWithCategory(this System.Type EnumType);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory(thisSystem.Type).EnumType'></a>

`EnumType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[GroupedEnumMember](EficazFramework.Extensions/GroupedEnumMember.md 'EficazFramework.Extensions.GroupedEnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember