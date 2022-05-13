using EficazFramework.Tests.Extensions;
using NUnit.Framework;
using System;

namespace EficazFramework.Tests;

public abstract class BunitTest
{
    protected Bunit.TestContext Context { get; private set; } = new();

    [SetUp]
    public virtual void Setup()
    {
        Context = new();
        Context.AddTestServices();
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            Context.Dispose();
        }
        catch (Exception)
        {
            /*ignore*/
        }
    }
}
