#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Enums.CRUD](EficazFrameworkData.md#EficazFramework_Enums_CRUD 'EficazFramework.Enums.CRUD')
## State Enum
Efetua a comunicação de estado entre ViewModel e View, posicionando a última na tela condizente ao estado da ViewModel.  
```csharp
public enum State

```
#### Fields
<a name='EficazFramework_Enums_CRUD_State_Bloqueado'></a>
`Bloqueado` 3  
A rotina CRUD não permite edição nem navegação.  
### Remarks
  
<a name='EficazFramework_Enums_CRUD_State_Edicao'></a>
`Edicao` 1  
A rotina CRUD está editando uma Entidade já existente.  
### Remarks
  
<a name='EficazFramework_Enums_CRUD_State_EdicaoDeDelhe'></a>
`EdicaoDeDelhe` 6  
A rotina CRUD está editando uma Entidade-Detalhe relacionada à Entidade-Mestre já existente.  
### Remarks
  
<a name='EficazFramework_Enums_CRUD_State_Leitura'></a>
`Leitura` 2  
A rotina CRUD está em modo Somente Leitura.  
### Remarks
  
<a name='EficazFramework_Enums_CRUD_State_Novo'></a>
`Novo` 0  
A rotina CRUD está em modo de Adição de nova Entidade.  
### Remarks
  
<a name='EficazFramework_Enums_CRUD_State_NovoDetalhe'></a>
`NovoDetalhe` 5  
A rotina CRUD está em modo de Adição de nova Entidade-Detalhe relacionada à Entidade-Mestre já existente.  
### Remarks
  
<a name='EficazFramework_Enums_CRUD_State_Processando'></a>
`Processando` 4  
A rotina CRUD está ocupada processando alguma operação.  
### Remarks
  
