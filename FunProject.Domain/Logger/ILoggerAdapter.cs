using System;

namespace FunProject.Domain.Logger
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message, params object[] args);
        void LogError(string message, params object[] args);
        void LogError(Exception exception, string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogWarning(Exception exception, string message, params object[] args);
    }
}
