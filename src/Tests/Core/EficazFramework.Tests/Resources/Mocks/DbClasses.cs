using EficazFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Resources.Mocks.Classes;

internal class Blog : Entities.EntityBase
{
    public System.Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }

    public List<Post> Posts { get; set; }

    public Owner Owner { get; set; }

}

internal class Post : Entities.EntityBase
{
    public Blog Blog { get; set; }  
    public System.Guid BlogId { get; set; }
    public System.Guid PostId { get; set; }
    public string Title { get; set; }

}

internal class Owner : Entities.EntityBase
{
    public string Name { get; set; }
}

internal class CustomViewModelService<T> : EficazFramework.ViewModels.Services.ViewModelService<T> where T : Entities.EntityBase, Entities.IEntity
{
    public CustomViewModelService(ViewModel<T> viewmodel) : base(viewmodel)
    {
    }
}
