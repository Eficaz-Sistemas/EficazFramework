#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Services](EficazFrameworkData.md#EficazFramework.Services 'EficazFramework.Services').[ServiceCollectionExtension](EficazFramework.Services/ServiceCollectionExtension.md 'EficazFramework.Services.ServiceCollectionExtension')

## ServiceCollectionExtension.AddEntityRepository<TEntity>(this IServiceCollection, Action<EntityRepositoryConfiguration<TEntity>>) Method

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddEntityRepository<TEntity>(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<EficazFramework.Configuration.EntityRepositoryConfiguration<TEntity>> options=null)
    where TEntity : EficazFramework.Entities.EntityBase;
```
#### Type parameters

<a name='EficazFramework.Services.ServiceCollectionExtension.AddEntityRepository_TEntity_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_EficazFramework.Configuration.EntityRepositoryConfiguration_TEntity__).TEntity'></a>

`TEntity`
#### Parameters

<a name='EficazFramework.Services.ServiceCollectionExtension.AddEntityRepository_TEntity_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_EficazFramework.Configuration.EntityRepositoryConfiguration_TEntity__).services'></a>

`services` [Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')

<a name='EficazFramework.Services.ServiceCollectionExtension.AddEntityRepository_TEntity_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_EficazFramework.Configuration.EntityRepositoryConfiguration_TEntity__).options'></a>

`options` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[EficazFramework.Configuration.EntityRepositoryConfiguration&lt;](EficazFramework.Configuration/EntityRepositoryConfiguration_TEntity_.md 'EficazFramework.Configuration.EntityRepositoryConfiguration<TEntity>')[TEntity](EficazFramework.Services/ServiceCollectionExtension/AddEntityRepository_TEntity_(thisIServiceCollection,Action_EntityRepositoryConfiguration_TEntity__).md#EficazFramework.Services.ServiceCollectionExtension.AddEntityRepository_TEntity_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_EficazFramework.Configuration.EntityRepositoryConfiguration_TEntity__).TEntity 'EficazFramework.Services.ServiceCollectionExtension.AddEntityRepository<TEntity>(this Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<EficazFramework.Configuration.EntityRepositoryConfiguration<TEntity>>).TEntity')[&gt;](EficazFramework.Configuration/EntityRepositoryConfiguration_TEntity_.md 'EficazFramework.Configuration.EntityRepositoryConfiguration<TEntity>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

#### Returns
[Microsoft.Extensions.DependencyInjection.IServiceCollection](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection')