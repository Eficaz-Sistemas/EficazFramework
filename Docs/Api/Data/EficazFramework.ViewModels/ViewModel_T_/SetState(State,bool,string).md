#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels](EficazFrameworkData.md#EficazFramework.ViewModels 'EficazFramework.ViewModels').[ViewModel&lt;T&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

## ViewModel<T>.SetState(State, bool, string) Method

Determina o estado de Loading e a Mensagem ao usuário

```csharp
public void SetState(EficazFramework.Enums.CRUD.State state, bool loading, string message=null);
```
#### Parameters

<a name='EficazFramework.ViewModels.ViewModel_T_.SetState(EficazFramework.Enums.CRUD.State,bool,string).state'></a>

`state` [State](EficazFramework.Enums.CRUD/State.md 'EficazFramework.Enums.CRUD.State')

<a name='EficazFramework.ViewModels.ViewModel_T_.SetState(EficazFramework.Enums.CRUD.State,bool,string).loading'></a>

`loading` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Estado de loading: True ou False

<a name='EficazFramework.ViewModels.ViewModel_T_.SetState(EficazFramework.Enums.CRUD.State,bool,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Mensagem de loading desejada