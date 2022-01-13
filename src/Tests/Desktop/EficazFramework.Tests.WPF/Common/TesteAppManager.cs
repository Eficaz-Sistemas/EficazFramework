using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Tests;

internal class TestContext
{
    internal static System.Windows.Application Application { get; } = new();
    internal static System.Windows.Window MainWindow { get; } = new();

}
