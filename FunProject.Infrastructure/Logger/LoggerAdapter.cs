using FunProject.Domain.Logger;
using Microsoft.Extensions.Logging;
using System;

namespace FunProject.Infrastructure.Logger
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            _logger.LogError(exception, message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogWarning(Exception exception, string message, params object[] args)
        {
            _logger.LogWarning(exception, message, args);
        }
    }
}
