#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Entities](EficazFrameworkData.md#EficazFramework.Entities 'EficazFramework.Entities').[EntityBase](EficazFramework.Entities/EntityBase.md 'EficazFramework.Entities.EntityBase')

## EntityBase.ErrorText(string) Method

Obtém o(s) erro(s) na Entity ou de uma de duas propriedades, através do método Validate() de cada plataforma.  
Implementa de INotifyPropertyChanged.ErrorText()

```csharp
public string ErrorText(string propertyName);
```
#### Parameters

<a name='EficazFramework.Entities.EntityBase.ErrorText(string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.

Implements [ErrorText(string)](EficazFramework.Entities/IEntity/ErrorText(string).md 'EficazFramework.Entities.IEntity.ErrorText(string)')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
IEnumerable

### Remarks