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

| Methods | |
| :--- | :--- |
| [AttachValidatorAndINotifyPropertyChanges(D)](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/AttachValidatorAndINotifyPropertyChanges(D).md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.AttachValidatorAndINotifyPropertyChanges(D)') | Anexa a instância de validação do repositório ao item especificado no parâmetro,<br/>além de iniciar a notificação de alteração pela interface INotifyPropertyChanged |
| [DeleteDetailCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/DeleteDetailCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.DeleteDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Delete |
| [DetachValidatorAndINotifyPropertyChanges(D)](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/DetachValidatorAndINotifyPropertyChanges(D).md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.DetachValidatorAndINotifyPropertyChanges(D)') | Remove a instância de validação do repositório ao item especificado no parâmetro,<br/>além de finalizar a notificação de alteração pela interface INotifyPropertyChanged |
| [GetCurrentEntryIndex()](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/GetCurrentEntryIndex().md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.GetCurrentEntryIndex()') | Obtém o índice de alocação do item selecionado para com o DataContext |
| [MoveNext()](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/MoveNext().md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.MoveNext()') | Seleciona o próximo item do DataContext, baseado no item atualmente selecionado |
| [MovePrevious()](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/MovePrevious().md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.MovePrevious()') | Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado |
| [MoveTo(D)](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/MoveTo(D).md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.MoveTo(D)') | Seleciona o item definido em argumento |
| [MoveToFirst()](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/MoveToFirst().md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.MoveToFirst()') | Seleciona o primeiro item do DataContext |
| [MoveToLast()](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/MoveToLast().md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.MoveToLast()') | Seleciona o último item do DataContext |
| [NewDetailCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/NewDetailCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.NewDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Novo |
| [OnMasterPropertyChanged(object, PropertyChangedEventArgs)](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/OnMasterPropertyChanged(object,PropertyChangedEventArgs).md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.OnMasterPropertyChanged(object, System.ComponentModel.PropertyChangedEventArgs)') | Acompanha a mudança de Entidade Atual do Serviço-Mestre. |
| [OnStateChanged(object, EventArgs)](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/OnStateChanged(object,EventArgs).md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.OnStateChanged(object, System.EventArgs)') | Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel Mestre. |
| [OnViewModelAction(object, CRUDEventArgs&lt;T&gt;)](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/OnViewModelAction(object,CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.OnViewModelAction(object, EficazFramework.Events.CRUDEventArgs<T>)') | Monitora a mudança de estado do ViewModel e executa os procedimentos <br/>necessários para exibição e tracking de entidades detalhes |
