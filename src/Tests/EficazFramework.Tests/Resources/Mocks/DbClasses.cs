using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Resources.Mocks.Classes;

class Blog
{
    public System.Guid Id { get; set; }   
    public string Name { get; set; }

    public List<Post> Posts { get; set; }

}

class Post
{
    public Blog Blog { get; set; }  
    public System.Guid BlogId { get; set; }
    public System.Guid PostId { get; set; }
    public string Title { get; set; }

}
