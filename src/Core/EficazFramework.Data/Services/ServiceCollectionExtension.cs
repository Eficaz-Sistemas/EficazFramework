using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
namespace EficazFramework.Services;

public static class ServiceCollectionExtension
{

    [ExcludeFromCodeCoverage]
    public static IServiceCollection AddEntityRepository<TEntity>(this IServiceCollection services, Action<Configuration.EntityRepositoryConfiguration<TEntity>> options = null) where TEntity : EficazFramework.Entities.EntityBase
    {
        Configuration.EntityRepositoryConfiguration<TEntity> config = new();
        if (options != null)
        {
            services.Configure(options);
            options.Invoke(config);
        }
        var instance = new Repositories.EntityRepository<TEntity>()
        {
            AsNoTracking = config.AsNoTracking,
            CustomFetch = config.CustomFetch,
            Validator = config.Validator,
            DbContextRequest = config.DbContextRequest
        };
        config.Includes.ForEach(i => instance.Includes.Add(i));

        services.AddScoped(x => instance);
        return services;
    }
}
