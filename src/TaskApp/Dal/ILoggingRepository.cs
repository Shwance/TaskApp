using System;
using Microsoft.Extensions.Logging;

namespace TaskApp.Dal
{
    public interface ILoggingRepository
    {
        void Log(String description, LogLevel logLevel);
    }
}
