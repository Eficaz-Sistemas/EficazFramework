using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Resources.Mocks.Classes;

public class Blog : Entities.EntityBase
{
    public System.Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Group { get; set; }   

    public List<Post> Posts { get; set; } = new();

    public Owner Owner { get; set; }

}

public class Post : Entities.EntityBase
{
    public Blog Blog { get; set; }  
    public System.Guid BlogId { get; set; }
    public System.Guid PostId { get; set; }
    public string Title { get; set; }

}

public class Owner : Entities.EntityBase
{
    public string Name { get; set; }
}
