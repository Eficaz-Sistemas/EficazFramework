#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')

## EficazFramework.Data Assembly
### Namespaces

<a name='EficazFramework.Configuration'></a>

## EficazFramework.Configuration Namespace

| Classes | |
| :--- | :--- |
| [DbConfiguration](EficazFramework.Configuration/DbConfiguration.md 'EficazFramework.Configuration.DbConfiguration') | |

<a name='EficazFramework.Entities'></a>

## EficazFramework.Entities Namespace

| Classes | |
| :--- | :--- |
| [EntityBase](EficazFramework.Entities/EntityBase.md 'EficazFramework.Entities.EntityBase') | Implementa o modelo-base de Entity para uso com EntityFrameworkCore.<br/>Deve ser herdado para implementar a validação de dados, seguindo os protocolos de cada Plataforma. |

<a name='EficazFramework.Enums'></a>

## EficazFramework.Enums Namespace

| Enums | |
| :--- | :--- |
| [CompareMethod](EficazFramework.Enums/CompareMethod.md 'EficazFramework.Enums.CompareMethod') | |

<a name='EficazFramework.Enums.CRUD'></a>

## EficazFramework.Enums.CRUD Namespace

| Enums | |
| :--- | :--- |
| [Action](EficazFramework.Enums.CRUD/Action.md 'EficazFramework.Enums.CRUD.Action') | Informa o momento em que o evento ViewModelAction foi disparado |
| [State](EficazFramework.Enums.CRUD/State.md 'EficazFramework.Enums.CRUD.State') | Efetua a comunicação de estado entre ViewModel e View, posicionando a última na tela condizente ao estado da ViewModel. |

<a name='EficazFramework.Extensions'></a>

## EficazFramework.Extensions Namespace

| Classes | |
| :--- | :--- |
| [DataReader](EficazFramework.Extensions/DataReader.md 'EficazFramework.Extensions.DataReader') | |
| [DbCommand](EficazFramework.Extensions/DbCommand.md 'EficazFramework.Extensions.DbCommand') | |
| [DbContext](EficazFramework.Extensions/DbContext.md 'EficazFramework.Extensions.DbContext') | |
| [Expressions](EficazFramework.Extensions/Expressions.md 'EficazFramework.Extensions.Expressions') | Refer to http://www.albahari.com/nutshell/linqkit.html and<br/>http://tomasp.net/blog/linq-expand.aspx for more information.<br/><br/>This is a part of LinqKit Tool.<br/>See http://www.albahari.com/expressions for information and examples. |

<a name='EficazFramework.Repositories'></a>

## EficazFramework.Repositories Namespace

| Classes | |
| :--- | :--- |
| [EntityRepository&lt;TEntity&gt;](EficazFramework.Repositories/EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository<TEntity>') | |
| [RepositoryBase&lt;T&gt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>') | |

<a name='EficazFramework.Validation.Fluent'></a>

## EficazFramework.Validation.Fluent Namespace

| Classes | |
| :--- | :--- |
| [ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult') | Lista resultante dos métodos de Validação |
| [Validator&lt;T&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>') | Classe definitiva da validação fluente, com estrutura genérica ao tipo a ser validado. |

| Interfaces | |
| :--- | :--- |
| [IValidator](EficazFramework.Validation.Fluent/IValidator.md 'EficazFramework.Validation.Fluent.IValidator') | Define a instrumentação inicial para validação fluente. |

<a name='EficazFramework.Validation.Fluent.Rules'></a>

## EficazFramework.Validation.Fluent.Rules Namespace

| Classes | |
| :--- | :--- |
| [Documentos&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Documentos_T_.md 'EficazFramework.Validation.Fluent.Rules.Documentos<T>') | |
| [Equals&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Equals_T_.md 'EficazFramework.Validation.Fluent.Rules.Equals<T>') | |
| [MaxLenght&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/MaxLenght_T_.md 'EficazFramework.Validation.Fluent.Rules.MaxLenght<T>') | |
| [MinLenght&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/MinLenght_T_.md 'EficazFramework.Validation.Fluent.Rules.MinLenght<T>') | |
| [Range&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Range_T_.md 'EficazFramework.Validation.Fluent.Rules.Range<T>') | |
| [RangePeriod&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/RangePeriod_T_.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod<T>') | |
| [Required&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Required_T_.md 'EficazFramework.Validation.Fluent.Rules.Required<T>') | |
| [RequiredIf&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/RequiredIf_T_.md 'EficazFramework.Validation.Fluent.Rules.RequiredIf<T>') | |
| [ValidationRule&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') | Classa padrão de regra de validação. Deve ser herdada. |
| [ValidatorUtils](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils') | Conunto de métodos auxiliares para composição das regras de validação in-built |

<a name='EficazFramework.ViewModels'></a>

## EficazFramework.ViewModels Namespace

| Classes | |
| :--- | :--- |
| [ViewModel&lt;T&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>') | Provê a estrutura básica de ViewModel em leitura tabular.<br/>Adicione funções, como operações CRUD e Registro de Repositório utilizando as extensões disponíveis |

<a name='EficazFramework.ViewModels.Services'></a>

## EficazFramework.ViewModels.Services Namespace

| Classes | |
| :--- | :--- |
| [IndexViewNavigator&lt;T&gt;](EficazFramework.ViewModels.Services/IndexViewNavigator_T_.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>') | |
| [ServiceUtils](EficazFramework.ViewModels.Services/ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils') | |
| [SingleEdit&lt;T&gt;](EficazFramework.ViewModels.Services/SingleEdit_T_.md 'EficazFramework.ViewModels.Services.SingleEdit<T>') | Serviço de gravação e/ou cancelamento de alterações para ViewModel |
| [SingleEditDetail&lt;T,D&gt;](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>') | |
| [TabularEdit&lt;T&gt;](EficazFramework.ViewModels.Services/TabularEdit_T_.md 'EficazFramework.ViewModels.Services.TabularEdit<T>') | Serviço de gravação e/ou cancelamento de alterações para ViewModel |
| [TabularEditDetail&lt;T,D&gt;](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>') | |
| [ViewModelService&lt;T&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') | |
