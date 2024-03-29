#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[Enums](EficazFramework.Extensions/Enums.md 'EficazFramework.Extensions.Enums')

## Enums.GetLocalizedValuesWithCategory<TEnum>(Type) Method

Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de TEnum

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.GroupedEnumMember> GetLocalizedValuesWithCategory<TEnum>(System.Type resourceType);
```
#### Type parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory_TEnum_(System.Type).TEnum'></a>

`TEnum`
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory_TEnum_(System.Type).resourceType'></a>

`resourceType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[GroupedEnumMember](EficazFramework.Extensions/GroupedEnumMember.md 'EficazFramework.Extensions.GroupedEnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember