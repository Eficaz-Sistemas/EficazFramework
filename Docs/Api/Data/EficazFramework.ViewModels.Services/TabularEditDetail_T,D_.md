#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## TabularEditDetail<T,D> Class

```csharp
public class TabularEditDetail<T,D> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
    where D : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.T'></a>

`T`

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.D'></a>

`D`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.T 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') &#129106; TabularEditDetail<T,D>
### Properties

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.CanAdd'></a>

## TabularEditDetail<T,D>.CanAdd Property

Notifica a View se os comando Novo está habilitado.

```csharp
public bool CanAdd { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.CanCancelAsyncSave'></a>

## TabularEditDetail<T,D>.CanCancelAsyncSave Property

Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.

```csharp
public bool CanCancelAsyncSave { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.CanModifyOrDelete'></a>

## TabularEditDetail<T,D>.CanModifyOrDelete Property

Notifica a View se os comandos Editar, Salvar e Excluir estão habilitados.

```csharp
public bool CanModifyOrDelete { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.CanSave'></a>

## TabularEditDetail<T,D>.CanSave Property

Notifica a View se o comando salvar está habilitado.

```csharp
public bool CanSave { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.CurrentEntry'></a>

## TabularEditDetail<T,D>.CurrentEntry Property

Obtém ou define a entidade atual em edição ou inserção.

```csharp
public D CurrentEntry { get; set; }
```

#### Property Value
[D](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.D 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.D')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.DataContext'></a>

## TabularEditDetail<T,D>.DataContext Property

Contém a cópia da enumeração dos resultados obtidos na propriedade de Navegação.

```csharp
public EficazFramework.Collections.AsyncObservableCollection<D> DataContext { get; set; }
```

#### Property Value
[EficazFramework.Collections.AsyncObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.AsyncObservableCollection-1 'EficazFramework.Collections.AsyncObservableCollection`1')[D](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.D 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.D')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.AsyncObservableCollection-1 'EficazFramework.Collections.AsyncObservableCollection`1')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.DeleteDataContext'></a>

## TabularEditDetail<T,D>.DeleteDataContext Property

Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master.

```csharp
public EficazFramework.Collections.AsyncObservableCollection<D> DeleteDataContext { get; set; }
```

#### Property Value
[EficazFramework.Collections.AsyncObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.AsyncObservableCollection-1 'EficazFramework.Collections.AsyncObservableCollection`1')[D](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.D 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.D')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.AsyncObservableCollection-1 'EficazFramework.Collections.AsyncObservableCollection`1')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.DetailValidator'></a>

## TabularEditDetail<T,D>.DetailValidator Property

Validador para Entidades Detalhe

```csharp
public EficazFramework.Validation.Fluent.Validator<D> DetailValidator { get; set; }
```

#### Property Value
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[D](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.D 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.D')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.InsertDataContext'></a>

## TabularEditDetail<T,D>.InsertDataContext Property

Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master.

```csharp
public EficazFramework.Collections.AsyncObservableCollection<D> InsertDataContext { get; set; }
```

#### Property Value
[EficazFramework.Collections.AsyncObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.AsyncObservableCollection-1 'EficazFramework.Collections.AsyncObservableCollection`1')[D](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.D 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.D')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.AsyncObservableCollection-1 'EficazFramework.Collections.AsyncObservableCollection`1')
### Methods

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.AttachValidatorAndINotifyPropertyChanges(D)'></a>

## TabularEditDetail<T,D>.AttachValidatorAndINotifyPropertyChanges(D) Method

Anexa a instância de validação do repositório ao item especificado no parâmetro,  
além de iniciar a notificação de alteração pela interface INotifyPropertyChanged

```csharp
private void AttachValidatorAndINotifyPropertyChanges(D entry);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.AttachValidatorAndINotifyPropertyChanges(D).entry'></a>

`entry` [D](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.D 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.D')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.DeleteDetailCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs)'></a>

## TabularEditDetail<T,D>.DeleteDetailCommand_Executed(object, ExecuteEventArgs) Method

Ações do comando Delete

```csharp
private void DeleteDetailCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.DeleteDetailCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.DeleteDetailCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).e'></a>

`e` [EficazFramework.Events.ExecuteEventArgs](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventArgs 'EficazFramework.Events.ExecuteEventArgs')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.DetachValidatorAndINotifyPropertyChanges(D)'></a>

## TabularEditDetail<T,D>.DetachValidatorAndINotifyPropertyChanges(D) Method

Remove a instância de validação do repositório ao item especificado no parâmetro,  
além de finalizar a notificação de alteração pela interface INotifyPropertyChanged

```csharp
private void DetachValidatorAndINotifyPropertyChanges(D entry);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.DetachValidatorAndINotifyPropertyChanges(D).entry'></a>

`entry` [D](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.D 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.D')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.GetCurrentEntryIndex()'></a>

## TabularEditDetail<T,D>.GetCurrentEntryIndex() Method

Obtém o índice de alocação do item selecionado para com o DataContext

```csharp
private int GetCurrentEntryIndex();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.MoveNext()'></a>

## TabularEditDetail<T,D>.MoveNext() Method

Seleciona o próximo item do DataContext, baseado no item atualmente selecionado

```csharp
public void MoveNext();
```

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.MovePrevious()'></a>

## TabularEditDetail<T,D>.MovePrevious() Method

Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado

```csharp
public void MovePrevious();
```

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.MoveTo(D)'></a>

## TabularEditDetail<T,D>.MoveTo(D) Method

Seleciona o item definido em argumento

```csharp
public void MoveTo(D entry);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.MoveTo(D).entry'></a>

`entry` [D](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.D 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.D')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.MoveToFirst()'></a>

## TabularEditDetail<T,D>.MoveToFirst() Method

Seleciona o primeiro item do DataContext

```csharp
public void MoveToFirst();
```

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.MoveToLast()'></a>

## TabularEditDetail<T,D>.MoveToLast() Method

Seleciona o último item do DataContext

```csharp
public void MoveToLast();
```

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.NewDetailCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs)'></a>

## TabularEditDetail<T,D>.NewDetailCommand_Executed(object, ExecuteEventArgs) Method

Ações do comando Novo

```csharp
private void NewDetailCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.NewDetailCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.NewDetailCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).e'></a>

`e` [EficazFramework.Events.ExecuteEventArgs](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventArgs 'EficazFramework.Events.ExecuteEventArgs')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.OnMasterPropertyChanged(object,System.ComponentModel.PropertyChangedEventArgs)'></a>

## TabularEditDetail<T,D>.OnMasterPropertyChanged(object, PropertyChangedEventArgs) Method

Acompanha a mudança de Entidade Atual do Serviço-Mestre.

```csharp
private void OnMasterPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.OnMasterPropertyChanged(object,System.ComponentModel.PropertyChangedEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.OnMasterPropertyChanged(object,System.ComponentModel.PropertyChangedEventArgs).e'></a>

`e` [System.ComponentModel.PropertyChangedEventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.OnStateChanged(object,System.EventArgs)'></a>

## TabularEditDetail<T,D>.OnStateChanged(object, EventArgs) Method

Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel Mestre.

```csharp
private void OnStateChanged(object sender, System.EventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.OnStateChanged(object,System.EventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.OnStateChanged(object,System.EventArgs).e'></a>

`e` [System.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System.EventArgs')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.OnViewModelAction(object,EficazFramework.Events.CRUDEventArgs_T_)'></a>

## TabularEditDetail<T,D>.OnViewModelAction(object, CRUDEventArgs<T>) Method

Monitora a mudança de estado do ViewModel e executa os procedimentos   
necessários para exibição e tracking de entidades detalhes

```csharp
private void OnViewModelAction(object sender, EficazFramework.Events.CRUDEventArgs<T> e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.OnViewModelAction(object,EficazFramework.Events.CRUDEventArgs_T_).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.OnViewModelAction(object,EficazFramework.Events.CRUDEventArgs_T_).e'></a>

`e` [EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.T 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')