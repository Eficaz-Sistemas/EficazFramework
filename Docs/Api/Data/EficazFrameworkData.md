#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')

## EficazFramework.Data Assembly
### Namespaces

<a name='EficazFramework.Attributes.UIEditor.EditingState'></a>

## EficazFramework.Attributes.UIEditor.EditingState Namespace

| Classes | |
| :--- | :--- |
| [EnabledIf](EficazFramework.Attributes.UIEditor.EditingState/EnabledIf.md 'EficazFramework.Attributes.UIEditor.EditingState.EnabledIf') | |
| [EnabledOnlyInStateAttribute](EficazFramework.Attributes.UIEditor.EditingState/EnabledOnlyInStateAttribute.md 'EficazFramework.Attributes.UIEditor.EditingState.EnabledOnlyInStateAttribute') | |
| [VisibleIfAttribute](EficazFramework.Attributes.UIEditor.EditingState/VisibleIfAttribute.md 'EficazFramework.Attributes.UIEditor.EditingState.VisibleIfAttribute') | |

<a name='EficazFramework.Attributes.UIEditor.EditorGeneration'></a>

## EficazFramework.Attributes.UIEditor.EditorGeneration Namespace

| Classes | |
| :--- | :--- |
| [CategoryAttribute](EficazFramework.Attributes.UIEditor.EditorGeneration/CategoryAttribute.md 'EficazFramework.Attributes.UIEditor.EditorGeneration.CategoryAttribute') | |
| [DocumentoAttribute](EficazFramework.Attributes.UIEditor.EditorGeneration/DocumentoAttribute.md 'EficazFramework.Attributes.UIEditor.EditorGeneration.DocumentoAttribute') | |
| [FixedHeightAttribute](EficazFramework.Attributes.UIEditor.EditorGeneration/FixedHeightAttribute.md 'EficazFramework.Attributes.UIEditor.EditorGeneration.FixedHeightAttribute') | |
| [IgnoreAttribute](EficazFramework.Attributes.UIEditor.EditorGeneration/IgnoreAttribute.md 'EficazFramework.Attributes.UIEditor.EditorGeneration.IgnoreAttribute') | |
| [MaxLengthAttribute](EficazFramework.Attributes.UIEditor.EditorGeneration/MaxLengthAttribute.md 'EficazFramework.Attributes.UIEditor.EditorGeneration.MaxLengthAttribute') | |

<a name='EficazFramework.Configuration'></a>

## EficazFramework.Configuration Namespace

| Classes | |
| :--- | :--- |
| [DbConfiguration](EficazFramework.Configuration/DbConfiguration.md 'EficazFramework.Configuration.DbConfiguration') | |
| [DbConfigurator](EficazFramework.Configuration/DbConfigurator.md 'EficazFramework.Configuration.DbConfigurator') | |
| [EntityRepositoryConfiguration&lt;TEntity&gt;](EficazFramework.Configuration/EntityRepositoryConfiguration_TEntity_.md 'EficazFramework.Configuration.EntityRepositoryConfiguration<TEntity>') | |

| Interfaces | |
| :--- | :--- |
| [IDbConfig](EficazFramework.Configuration/IDbConfig.md 'EficazFramework.Configuration.IDbConfig') | |

<a name='EficazFramework.Entities'></a>

## EficazFramework.Entities Namespace

| Classes | |
| :--- | :--- |
| [EntityBase](EficazFramework.Entities/EntityBase.md 'EficazFramework.Entities.EntityBase') | Implementa o modelo-base de Entity para uso com EntityFrameworkCore.<br/>Deve ser herdado para implementar a validação de dados, seguindo os protocolos de cada Plataforma. |
| [EntityMappingConfigurator](EficazFramework.Entities/EntityMappingConfigurator.md 'EficazFramework.Entities.EntityMappingConfigurator') | |

| Interfaces | |
| :--- | :--- |
| [IEntity](EficazFramework.Entities/IEntity.md 'EficazFramework.Entities.IEntity') | |

<a name='EficazFramework.Enums'></a>

## EficazFramework.Enums Namespace

| Enums | |
| :--- | :--- |
| [ValidationMode](EficazFramework.Enums/ValidationMode.md 'EficazFramework.Enums.ValidationMode') | |

<a name='EficazFramework.Enums.CRUD'></a>

## EficazFramework.Enums.CRUD Namespace

| Enums | |
| :--- | :--- |
| [Action](EficazFramework.Enums.CRUD/Action.md 'EficazFramework.Enums.CRUD.Action') | Informa o momento em que o evento ViewModelAction foi disparado |
| [RequestAction](EficazFramework.Enums.CRUD/RequestAction.md 'EficazFramework.Enums.CRUD.RequestAction') | Utilizado em [ApiRepository&lt;TEntity&gt;](EficazFramework.Repositories/ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository<TEntity>') para determiner qual ação o método [RequestMethod&lt;TBody,TResult&gt;(RequestAction, string, TBody, CancellationToken)](EficazFramework.Repositories/ApiRepository_TEntity_/RequestMethod_TBody,TResult_(RequestAction,string,TBody,CancellationToken).md 'EficazFramework.Repositories.ApiRepository<TEntity>.RequestMethod<TBody,TResult>(EficazFramework.Enums.CRUD.RequestAction, string, TBody, System.Threading.CancellationToken)') deve executar. |
| [State](EficazFramework.Enums.CRUD/State.md 'EficazFramework.Enums.CRUD.State') | Efetua a comunicação de estado entre ViewModel e View, posicionando a última na tela condizente ao estado da ViewModel. |

<a name='EficazFramework.Events'></a>

## EficazFramework.Events Namespace

| Classes | |
| :--- | :--- |
| [CRUDEventArgs&lt;T&gt;](EficazFramework.Events/CRUDEventArgs_T_.md 'EficazFramework.Events.CRUDEventArgs<T>') | |
| [DbContextConfiguringEventArgs](EficazFramework.Events/DbContextConfiguringEventArgs.md 'EficazFramework.Events.DbContextConfiguringEventArgs') | |
| [DbContextInstanceCreatingEventArgs](EficazFramework.Events/DbContextInstanceCreatingEventArgs.md 'EficazFramework.Events.DbContextInstanceCreatingEventArgs') | |
| [DbContextModelCreatingEventArgs](EficazFramework.Events/DbContextModelCreatingEventArgs.md 'EficazFramework.Events.DbContextModelCreatingEventArgs') | |

| Delegates | |
| :--- | :--- |
| [CRUDEventHandler&lt;T&gt;(object, CRUDEventArgs&lt;T&gt;)](EficazFramework.Events/CRUDEventHandler_T_(object,CRUDEventArgs_T_).md 'EficazFramework.Events.CRUDEventHandler<T>(object, EficazFramework.Events.CRUDEventArgs<T>)') | |
| [DbContextConfiguringEventHandler(DbContext, DbContextConfiguringEventArgs)](EficazFramework.Events/DbContextConfiguringEventHandler(DbContext,DbContextConfiguringEventArgs).md 'EficazFramework.Events.DbContextConfiguringEventHandler(DbContext, EficazFramework.Events.DbContextConfiguringEventArgs)') | |
| [DbContextInstanceCreatingEventHandler(object, DbContextInstanceCreatingEventArgs)](EficazFramework.Events/DbContextInstanceCreatingEventHandler(object,DbContextInstanceCreatingEventArgs).md 'EficazFramework.Events.DbContextInstanceCreatingEventHandler(object, EficazFramework.Events.DbContextInstanceCreatingEventArgs)') | |
| [DbContextModelCreatingEventHandler(DbContext, DbContextModelCreatingEventArgs)](EficazFramework.Events/DbContextModelCreatingEventHandler(DbContext,DbContextModelCreatingEventArgs).md 'EficazFramework.Events.DbContextModelCreatingEventHandler(DbContext, EficazFramework.Events.DbContextModelCreatingEventArgs)') | |

<a name='EficazFramework.Extensions'></a>

## EficazFramework.Extensions Namespace

| Classes | |
| :--- | :--- |
| [DataReader](EficazFramework.Extensions/DataReader.md 'EficazFramework.Extensions.DataReader') | |
| [DbCommand](EficazFramework.Extensions/DbCommand.md 'EficazFramework.Extensions.DbCommand') | |
| [DbContext](EficazFramework.Extensions/DbContext.md 'EficazFramework.Extensions.DbContext') | |
| [QueryOperations](EficazFramework.Extensions/QueryOperations.md 'EficazFramework.Extensions.QueryOperations') | |

<a name='EficazFramework.Providers'></a>

## EficazFramework.Providers Namespace

| Classes | |
| :--- | :--- |
| [DataProviderBase](EficazFramework.Providers/DataProviderBase.md 'EficazFramework.Providers.DataProviderBase') | Definição abstrata de provedor de acesso à base. |

<a name='EficazFramework.Repositories'></a>

## EficazFramework.Repositories Namespace

| Classes | |
| :--- | :--- |
| [ApiRepository&lt;TEntity&gt;](EficazFramework.Repositories/ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository<TEntity>') | |
| [EntityRepository&lt;TEntity&gt;](EficazFramework.Repositories/EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository<TEntity>') | |
| [RepositoryBase&lt;T&gt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>') | |

| Interfaces | |
| :--- | :--- |
| [IAuditableRepository](EficazFramework.Repositories/IAuditableRepository.md 'EficazFramework.Repositories.IAuditableRepository') | |
| [IEntityRepository](EficazFramework.Repositories/IEntityRepository.md 'EficazFramework.Repositories.IEntityRepository') | |

<a name='EficazFramework.Repositories.Services'></a>

## EficazFramework.Repositories.Services Namespace

| Classes | |
| :--- | :--- |
| [QueryBase](EficazFramework.Repositories.Services/QueryBase.md 'EficazFramework.Repositories.Services.QueryBase') | |

<a name='EficazFramework.Security'></a>

## EficazFramework.Security Namespace

| Classes | |
| :--- | :--- |
| [AuditModel](EficazFramework.Security/AuditModel.md 'EficazFramework.Security.AuditModel') | |

<a name='EficazFramework.Services'></a>

## EficazFramework.Services Namespace

| Classes | |
| :--- | :--- |
| [ServiceCollectionExtension](EficazFramework.Services/ServiceCollectionExtension.md 'EficazFramework.Services.ServiceCollectionExtension') | |

<a name='EficazFramework.Validation'></a>

## EficazFramework.Validation Namespace

| Classes | |
| :--- | :--- |
| [Definitions](EficazFramework.Validation/Definitions.md 'EficazFramework.Validation.Definitions') | |

| Interfaces | |
| :--- | :--- |
| [IFluentValidatableClass](EficazFramework.Validation/IFluentValidatableClass.md 'EficazFramework.Validation.IFluentValidatableClass') | |

<a name='EficazFramework.Validation.DataAnnotations'></a>

## EficazFramework.Validation.DataAnnotations Namespace

| Classes | |
| :--- | :--- |
| [DocumentoRFB](EficazFramework.Validation.DataAnnotations/DocumentoRFB.md 'EficazFramework.Validation.DataAnnotations.DocumentoRFB') | |
| [EMail](EficazFramework.Validation.DataAnnotations/EMail.md 'EficazFramework.Validation.DataAnnotations.EMail') | |
| [IncricaoEstadual](EficazFramework.Validation.DataAnnotations/IncricaoEstadual.md 'EficazFramework.Validation.DataAnnotations.IncricaoEstadual') | |

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
| [CNPJ&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/CNPJ_T_.md 'EficazFramework.Validation.Fluent.Rules.CNPJ<T>') | |
| [CNPJouCPF&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/CNPJouCPF_T_.md 'EficazFramework.Validation.Fluent.Rules.CNPJouCPF<T>') | |
| [Contatos&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Contatos_T_.md 'EficazFramework.Validation.Fluent.Rules.Contatos<T>') | |
| [CPF&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/CPF_T_.md 'EficazFramework.Validation.Fluent.Rules.CPF<T>') | |
| [Documentos&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Documentos_T_.md 'EficazFramework.Validation.Fluent.Rules.Documentos<T>') | |
| [EMail&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/EMail_T_.md 'EficazFramework.Validation.Fluent.Rules.EMail<T>') | |
| [InscrEstadual&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/InscrEstadual_T_.md 'EficazFramework.Validation.Fluent.Rules.InscrEstadual<T>') | |
| [PIS&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/PIS_T_.md 'EficazFramework.Validation.Fluent.Rules.PIS<T>') | |
| [ValidationRule&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') | Classa padrão de regra de validação. Deve ser herdada. |
| [ValidatorUtils](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils') | Conunto de métodos auxiliares para composição das regras de validação in-built |

| Enums | |
| :--- | :--- |
| [RangeMode](EficazFramework.Validation.Fluent.Rules/RangeMode.md 'EficazFramework.Validation.Fluent.Rules.RangeMode') | |

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
| [RestApiBuilderOptions](EficazFramework.ViewModels.Services/RestApiBuilderOptions.md 'EficazFramework.ViewModels.Services.RestApiBuilderOptions') | |
| [ServiceUtils](EficazFramework.ViewModels.Services/ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils') | |
| [SingleEdit&lt;T&gt;](EficazFramework.ViewModels.Services/SingleEdit_T_.md 'EficazFramework.ViewModels.Services.SingleEdit<T>') | Serviço de gravação e/ou cancelamento de alterações para ViewModel |
| [SingleEditDetail&lt;T,D&gt;](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>') | |
| [TabularEdit&lt;T&gt;](EficazFramework.ViewModels.Services/TabularEdit_T_.md 'EficazFramework.ViewModels.Services.TabularEdit<T>') | Serviço de gravação e/ou cancelamento de alterações para ViewModel |
| [TabularEditDetail&lt;T,D&gt;](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>') | |
| [ViewModelService&lt;T&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') | |
