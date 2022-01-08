using EficazFramework.Configuration;
using EficazFramework.Repositories.Services;
using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Providers;

public abstract class MsSqlServer : DataProviderBase
{
    public override string GetCommandText([NotNull] QueryBase queryBase) => queryBase.MsSqlCommandText;

}