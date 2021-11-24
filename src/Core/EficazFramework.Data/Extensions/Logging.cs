using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EficazFramework.Extensions
{
    public class DbContextLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new DbContextLogger();
            // If categoryName = GetType(IRelationalCommandBuilderFactory).FullName Then Return New DbContextLogger() Else Return New DbContextNullLogger
        }

        public void Dispose()
        {
        }

        private class DbContextLogger : ILogger
        {
            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                // File.AppendAllText("C:\temp\log.txt", formatter(state, exception))
                Debug.WriteLine(formatter(state, exception));
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }

        private class DbContextNullLogger : ILogger
        {
            public bool IsEnabled(LogLevel logLevel)
            {
                return false;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}