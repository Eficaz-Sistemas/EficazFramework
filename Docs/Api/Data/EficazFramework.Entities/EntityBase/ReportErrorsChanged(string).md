#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Entities](EficazFrameworkData.md#EficazFramework.Entities 'EficazFramework.Entities').[EntityBase](EficazFramework.Entities/EntityBase.md 'EficazFramework.Entities.EntityBase')

## EntityBase.ReportErrorsChanged(string) Method

Força a atualização da View para retirar estados de erros inválidos após sincroniza de relacionamentos entre tabelas de bancos diferentes.

```csharp
public void ReportErrorsChanged(string propertyName);
```
#### Parameters

<a name='EficazFramework.Entities.EntityBase.ReportErrorsChanged(string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.

### Remarks