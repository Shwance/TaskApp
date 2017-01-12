using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TaskApp.Dal;

namespace TaskApp.Logging
{
    public class DBLogger : ILogger
    {
        public DBLogger(ILoggingRepository repository, Boolean debugOn = false)
        {
            _repository = repository;
        }

        private ILoggingRepository _repository;
        private Boolean _debugOn;

        public void Log(String description, LogLevel logLevel)
        {
            if (_debugOn == true || logLevel != LogLevel.Debug)
            {
                _repository.Log(description, logLevel);
            }
        }
    }
}
