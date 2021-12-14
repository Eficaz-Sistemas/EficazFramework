using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.Extensions;

class DbCommand
{
    [Test]
    public void AddParameterTest()
    {
        var command = new SqlCommand();
        command.Parameters.Count.Should().Be(0);
        command.AddParameter();
        command.Parameters.Count.Should().Be(1);
        command.AddParameter<string>("@param1", "param 1 value");
        command.Parameters.Count.Should().Be(2);
        command.AddParameter().SetName("@param2").SetValue("param 2 value");
        command.Parameters.Count.Should().Be(3);

        command.Parameters[0].ParameterName.Should().Be("Parameter1");
        command.Parameters[0].Value.Should().Be(null);
        command.Parameters[1].ParameterName.Should().Be("@param1");
        command.Parameters[1].Value.Should().Be("param 1 value");
        command.Parameters[2].ParameterName.Should().Be("@param2");
        command.Parameters[2].Value.Should().Be("param 2 value");

    }
}
