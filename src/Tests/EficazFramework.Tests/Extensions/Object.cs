using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.Extensions;

class ObjectTests
{
    [Test]
    public void ReflectionTest()
    {
        Resources.Mocks.Classes.Post instance = new()
        {
            Blog = new Resources.Mocks.Classes.Blog()
            {
                Id = System.Guid.NewGuid(),
                Name = "My Blog"
            },
            BlogId = System.Guid.NewGuid(),
            Title = "My First Post"
        };
        object nullref = null;

        // single
        var pInfo = instance.GetPropertyInfo("Title", ref nullref);
        pInfo.Should().NotBeNull();
        pInfo.Name.Should().Be("Title");
        var value1 = pInfo.GetValue(instance);
        value1.Should().Be(instance.Title);
        var value2 = instance.GetPropertyValue("Title");
        value2.Should().Be(value1);
        instance.SetPropertyValue("Title", "My Old Post");
        instance.Title.Should().Be("My Old Post");

        // complex
        pInfo = instance.GetPropertyInfo("Blog.Name", ref nullref);
        pInfo.Should().NotBeNull();
        pInfo.Name.Should().Be("Name");
        value1 = pInfo.GetValue(instance.Blog);
        value1.Should().Be(instance.Blog.Name);
        value2 = instance.GetPropertyValue("Blog.Name");
        value2.Should().Be(value1);
        instance.SetPropertyValue("Blog.Name", "My Old Blog");
        instance.Blog.Name.Should().Be("My Old Blog");
    }
}
