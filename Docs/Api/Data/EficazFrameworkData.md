#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### Namespaces
<a name='EficazFramework_Configuration'></a>
## EficazFramework.Configuration Namespace

| Classes | |
| :--- | :--- |
| [DbConfiguration](DbConfiguration.md 'EficazFramework.Configuration.DbConfiguration') |  |
  
<a name='EficazFramework_Entities'></a>
## EficazFramework.Entities Namespace

| Classes | |
| :--- | :--- |
| [EntityBase](EntityBase.md 'EficazFramework.Entities.EntityBase') | Implementa o modelo-base de Entity para uso com EntityFrameworkCore.<br/>Deve ser herdado para implementar a validação de dados, seguindo os protocolos de cada Plataforma.<br/> |
  
<a name='EficazFramework_Enums'></a>
## EficazFramework.Enums Namespace

| Enums | |
| :--- | :--- |
| [CompareMethod](CompareMethod.md 'EficazFramework.Enums.CompareMethod') |  |
  
<a name='EficazFramework_Enums_CRUD'></a>
## EficazFramework.Enums.CRUD Namespace

| Enums | |
| :--- | :--- |
| [Action](Action.md 'EficazFramework.Enums.CRUD.Action') | Informa o momento em que o evento ViewModelAction foi disparado<br/> |
| [State](State.md 'EficazFramework.Enums.CRUD.State') | Efetua a comunicação de estado entre ViewModel e View, posicionando a última na tela condizente ao estado da ViewModel.<br/> |
  
<a name='EficazFramework_Extensions'></a>
## EficazFramework.Extensions Namespace

| Classes | |
| :--- | :--- |
| [DataReader](DataReader.md 'EficazFramework.Extensions.DataReader') |  |
| [DbCommand](DbCommand.md 'EficazFramework.Extensions.DbCommand') |  |
| [DbContext](DbContext.md 'EficazFramework.Extensions.DbContext') |  |
| [ExpandableQuery&lt;T&gt;](ExpandableQuery_T_.md 'EficazFramework.Extensions.ExpandableQuery&lt;T&gt;') | An IQueryable wrapper that allows us to visit the query's expression tree just before LINQ to SQL gets to it.<br/>This is based on the excellent work of Tomas Petricek: http://tomasp.net/blog/linq-expand.aspx<br/> |
| [ExpressionExpander](ExpressionExpander.md 'EficazFramework.Extensions.ExpressionExpander') | Custom expresssion visitor for ExpandableQuery. This expands calls to Expression.Compile() and<br/>collapses captured lambda references in subqueries which LINQ to SQL can't otherwise handle.<br/> |
| [Expressions](Expressions.md 'EficazFramework.Extensions.Expressions') | Refer to http://www.albahari.com/nutshell/linqkit.html and<br/>http://tomasp.net/blog/linq-expand.aspx for more information.<br/><br/>This is a part of LinqKit Tool.<br/>See http://www.albahari.com/expressions for information and examples.<br/> |
| [ExpressionVisitor](ExpressionVisitor.md 'EficazFramework.Extensions.ExpressionVisitor') | This comes from Matt Warren's sample:<br/>http://blogs.msdn.com/mattwar/archive/2007/07/31/linq-building-an-iqueryable-provider-part-ii.aspx<br/> |
  
<a name='EficazFramework_Providers'></a>
## EficazFramework.Providers Namespace

| Enums | |
| :--- | :--- |
| [ConnectionProviders](ConnectionProviders.md 'EficazFramework.Providers.ConnectionProviders') |  |
  
<a name='EficazFramework_Repositories'></a>
## EficazFramework.Repositories Namespace

| Classes | |
| :--- | :--- |
| [ApiRepository&lt;TEntity&gt;](ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository&lt;TEntity&gt;') |  |
| [DataImportRepository&lt;TSource,TCache&gt;](DataImportRepository_TSource_TCache_.md 'EficazFramework.Repositories.DataImportRepository&lt;TSource,TCache&gt;') |  |
| [EntityRepository&lt;TEntity&gt;](EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository&lt;TEntity&gt;') |  |
| [RepositoryBase&lt;T&gt;](RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;') |  |
  
<a name='EficazFramework_Security'></a>
## EficazFramework.Security Namespace

| Classes | |
| :--- | :--- |
| [Role](Role.md 'EficazFramework.Security.Role') |  |
| [RoleEditor](RoleEditor.md 'EficazFramework.Security.RoleEditor') |  |
| [RoleMember](RoleMember.md 'EficazFramework.Security.RoleMember') |  |
  
<a name='EficazFramework_Validation_Fluent'></a>
## EficazFramework.Validation.Fluent Namespace

| Classes | |
| :--- | :--- |
| [ValidationResult](ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult') | Lista resultante dos métodos de Validação<br/> |
| [Validator&lt;T&gt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;') | Classe definitiva da validação fluente, com estrutura genérica ao tipo a ser validado.<br/> |

| Interfaces | |
| :--- | :--- |
| [IValidator](IValidator.md 'EficazFramework.Validation.Fluent.IValidator') | Define a instrumentação inicial para validação fluente.<br/> |
  
<a name='EficazFramework_Validation_Fluent_Rules'></a>
## EficazFramework.Validation.Fluent.Rules Namespace

| Classes | |
| :--- | :--- |
| [Documentos&lt;T&gt;](Documentos_T_.md 'EficazFramework.Validation.Fluent.Rules.Documentos&lt;T&gt;') |  |
| [Equals&lt;T&gt;](Equals_T_.md 'EficazFramework.Validation.Fluent.Rules.Equals&lt;T&gt;') |  |
| [MaxLenght&lt;T&gt;](MaxLenght_T_.md 'EficazFramework.Validation.Fluent.Rules.MaxLenght&lt;T&gt;') |  |
| [MinLenght&lt;T&gt;](MinLenght_T_.md 'EficazFramework.Validation.Fluent.Rules.MinLenght&lt;T&gt;') |  |
| [Range&lt;T&gt;](Range_T_.md 'EficazFramework.Validation.Fluent.Rules.Range&lt;T&gt;') |  |
| [RangePeriod&lt;T&gt;](RangePeriod_T_.md 'EficazFramework.Validation.Fluent.Rules.RangePeriod&lt;T&gt;') |  |
| [Required&lt;T&gt;](Required_T_.md 'EficazFramework.Validation.Fluent.Rules.Required&lt;T&gt;') |  |
| [RequiredIf&lt;T&gt;](RequiredIf_T_.md 'EficazFramework.Validation.Fluent.Rules.RequiredIf&lt;T&gt;') |  |
| [Test&lt;T&gt;](Test_T_.md 'EficazFramework.Validation.Fluent.Rules.Test&lt;T&gt;') |  |
| [ValidationRule&lt;T&gt;](ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;T&gt;') | Classa padrão de regra de validação. Deve ser herdada.<br/> |
| [ValidatorUtils](ValidatorUtils.md 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils') | Conunto de métodos auxiliares para composição das regras de validação in-built<br/> |
  
<a name='EficazFramework_ViewModels'></a>
## EficazFramework.ViewModels Namespace

| Classes | |
| :--- | :--- |
| [ViewModel&lt;T&gt;](ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;') | Provê a estrutura básica de ViewModel em leitura tabular.<br/>Adicione funções, como operações CRUD e Registro de Repositório utilizando as extensões disponíveis<br/> |
  
<a name='EficazFramework_ViewModels_Services'></a>
## EficazFramework.ViewModels.Services Namespace

| Classes | |
| :--- | :--- |
| [Audit&lt;T&gt;](Audit_T_.md 'EficazFramework.ViewModels.Services.Audit&lt;T&gt;') |  |
| [GPO&lt;T&gt;](GPO_T_.md 'EficazFramework.ViewModels.Services.GPO&lt;T&gt;') |  |
| [IndexViewNavigator&lt;T&gt;](IndexViewNavigator_T_.md 'EficazFramework.ViewModels.Services.IndexViewNavigator&lt;T&gt;') |  |
| [PagedViewNavigator&lt;T&gt;](PagedViewNavigator_T_.md 'EficazFramework.ViewModels.Services.PagedViewNavigator&lt;T&gt;') |  |
| [ServiceUtils](ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils') |  |
| [SingleEdit&lt;T&gt;](SingleEdit_T_.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;') | Serviço de gravação e/ou cancelamento de alterações para ViewModel<br/> |
| [SingleEditDetail&lt;T,D&gt;](SingleEditDetail_T_D_.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;') |  |
| [TabularEdit&lt;T&gt;](TabularEdit_T_.md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;') | Serviço de gravação e/ou cancelamento de alterações para ViewModel<br/> |
| [TabularEditDetail&lt;T,D&gt;](TabularEditDetail_T_D_.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;') |  |
| [ViewModelService&lt;T&gt;](ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;') |  |
  
