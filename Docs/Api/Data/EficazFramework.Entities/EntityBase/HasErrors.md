#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Entities](EficazFrameworkData.md#EficazFramework.Entities 'EficazFramework.Entities').[EntityBase](EficazFramework.Entities/EntityBase.md 'EficazFramework.Entities.EntityBase')

## EntityBase.HasErrors Property

Retorna verdadeiro caso o objeto possua erro ou falso caso esteja OK.  
Porém FORÇA a validação de todo o objeto.  
Implementa de INotifyPropertyChanged.HasErrors

```csharp
public bool HasErrors { get; }
```

Implements [HasErrors](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyDataErrorInfo.HasErrors 'System.ComponentModel.INotifyDataErrorInfo.HasErrors'), [HasErrors](EficazFramework.Entities/IEntity/HasErrors.md 'EficazFramework.Entities.IEntity.HasErrors')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### Remarks