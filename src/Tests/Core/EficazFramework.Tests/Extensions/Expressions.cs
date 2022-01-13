using NUnit.Framework;
using System;
using System.Linq.Expressions;
using FluentAssertions;
using System.Collections.Generic;

namespace EficazFramework.Extensions;

class Expressions
{
    [Test]
    public void AndTest()
    {
        // string representation
        Expression<Func<string, bool>> leftExpression = (str) => str == "I'm the left";
        leftExpression.Body.ToString().Should().Be("(str == \"I'm the left\")");
        Expression <Func<string, bool>> rightExpression = (str) => str == "I'm the right";
        var andExpression = leftExpression.And(rightExpression);
        andExpression.Body.ToString().Should().Be("((str == \"I'm the left\") And (str == \"I'm the right\"))");

        //evaluation
        leftExpression = (str) => str.ToLower().Contains("left");
        leftExpression.Invoke("left").Should().BeTrue();
        leftExpression.Invoke("right").Should().BeFalse();

        rightExpression = (str) => str.ToLower().Contains("right");
        rightExpression.Invoke("left").Should().BeFalse();
        rightExpression.Invoke("right").Should().BeTrue();

        andExpression = leftExpression.And(rightExpression);
        andExpression.Body.ToString().Should().Be("(str.ToLower().Contains(\"left\") And str.ToLower().Contains(\"right\"))");
        //andExpression.Invoke("left").Should().BeTrue();
        //andExpression.Invoke("right").Should().BeTrue();
        //andExpression.Invoke("center").Should().BeFalse();
    }

    [Test]
    public void ForEachTest()
    {
        IEnumerable<int> myList = new List<int>()
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10
        };
        int counter = 0;
        myList.ForEach((int i) =>
        {
            counter++;
            counter.Should().Be(i);
        });
        counter.Should().Be(10);
    }

    [Test]
    public void GetNameTest()
    {
        Expression<Func<Resources.Mocks.Classes.Blog, string>> expression = (blog) => blog.Name;
        expression.GetName().Should().Be(nameof(Resources.Mocks.Classes.Blog.Name));
    }
}
