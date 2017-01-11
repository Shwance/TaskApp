using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Logging
{
    public static class TaskAppLoggerExtensions
    {

        public static ILoggerFactory AddTaskLogger(this ILoggerFactory factory,
                                                    ILoggingService loggingService,
                                                    Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new TaskAppLoggerProvider(filter, loggingService));

            return factory;

        }

    }
}
