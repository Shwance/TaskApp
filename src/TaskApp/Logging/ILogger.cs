using System;
using Microsoft.Extensions.Logging;

namespace TaskApp.Logging
{
    public interface ILogger
    {
        void Log(String description, LogLevel logLevel);
    }
}
