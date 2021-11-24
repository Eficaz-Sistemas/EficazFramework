#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Entities](EficazFrameworkData.md#EficazFramework_Entities 'EficazFramework.Entities').[EntityBase](EntityBase.md 'EficazFramework.Entities.EntityBase')
## EntityBase.GetErrors(string) Method
Obtém o(s) erro(s) na Entity ou de uma de duas propriedades, através do método Validate() de cada plataforma.  
```csharp
public System.Collections.IEnumerable GetErrors(string propertyName);
```
#### Parameters
<a name='EficazFramework_Entities_EntityBase_GetErrors(string)_propertyName'></a>
`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.
  
#### Returns
[System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  
IEnumerable

Implements [GetErrors(string?)](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyDataErrorInfo.GetErrors#System_ComponentModel_INotifyDataErrorInfo_GetErrors_System_String_ 'System.ComponentModel.INotifyDataErrorInfo.GetErrors(System.String)'), [GetErrors(string)](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Entities.IEntity.GetErrors#EficazFramework_Entities_IEntity_GetErrors_System_String_ 'EficazFramework.Entities.IEntity.GetErrors(System.String)')  
### Remarks
