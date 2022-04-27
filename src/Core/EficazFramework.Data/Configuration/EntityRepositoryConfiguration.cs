using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace EficazFramework.Configuration;

[ExcludeFromCodeCoverage]
public class EntityRepositoryConfiguration<TEntity> where TEntity : EficazFramework.Entities.EntityBase
{
    public bool AsNoTracking { get; set; }
    public Validation.Fluent.Validator<TEntity> Validator { get; set; }
    public Func<Task<IEnumerable<TEntity>>> CustomFetch { get; set; }
    public List<System.Linq.Expressions.Expression<Func<TEntity, object>>> Includes { get; private set; } = new();
    public Func<Microsoft.EntityFrameworkCore.DbContext> DbContextRequest { get; set; } = null;
}
