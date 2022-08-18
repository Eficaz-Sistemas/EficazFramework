using EficazFramework.ViewModels;
using System;
using System.Collections.Generic;

namespace EficazFramework.Resources.Mocks.Classes;

internal class BlogEntity : Entities.EntityBase
{
    public System.Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }

    public override string ToString()
    {
        return Id.ToString();
    }

}
