#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Entities](EficazFrameworkData.md#EficazFramework.Entities 'EficazFramework.Entities').[EntityBase](EficazFramework.Entities/EntityBase.md 'EficazFramework.Entities.EntityBase')

## EntityBase.Validate(string) Method

Método de validação funcional em diferentes plataformas, exceto Windows Phone 7.x.

```csharp
public EficazFramework.Collections.StringCollection Validate(string propertyName);
```
#### Parameters

<a name='EficazFramework.Entities.EntityBase.Validate(string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.

Implements [Validate(string)](EficazFramework.Entities/IEntity/Validate(string).md 'EficazFramework.Entities.IEntity.Validate(string)')

#### Returns
[EficazFramework.Collections.StringCollection](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.StringCollection 'EficazFramework.Collections.StringCollection')

### Remarks