using Microsoft.Extensions.Logging;
using System;


namespace TaskApp.Logging
{
    public class TaskAppLogger : ILogger
    {
        private String _categoryName;
        private Func<string, LogLevel, bool> _filter;
        private ILoggingService _logService;

        public TaskAppLogger(String categoryName, Func<string, LogLevel, bool> filter, ILoggingService logService)
        {
            _categoryName = categoryName;
            _filter = filter;
            _logService = logService;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public Boolean IsEnabled(LogLevel logLevel)
        {
            return (_filter == null || _filter(_categoryName, logLevel));
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (String.IsNullOrEmpty(message))
            {
                return;
            }

            message = $"{ logLevel }: {message}";

            if (exception != null)
            {
                _logService.Log(message);
            }
        }
    }
}
