using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EficazFramework.Services;

public static class ServiceCollectionExtension
{

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
