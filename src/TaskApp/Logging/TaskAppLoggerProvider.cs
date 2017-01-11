using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Logging
{
    public class TaskAppLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly ILoggingService _logService;

        public TaskAppLoggerProvider(Func<string, LogLevel, bool> filter, ILoggingService logService)
        {
            _logService = logService;
            _filter = filter;
        }

        public ILogger CreateLogger(String categoryName)
        {
            return new TaskAppLogger(categoryName, _filter, _logService);
        }

        public void Dispose()
        {
            this.Dispose();
        }

    }
}
