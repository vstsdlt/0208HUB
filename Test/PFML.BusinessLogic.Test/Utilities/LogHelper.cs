using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;

namespace PFML.BusinessLogic.Test.Logging
{
    public enum LoggingLevel : byte
    {
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    }

    public static class LogHelper
    {
        private static readonly Dictionary<Type, ILog> _loggers = new Dictionary<Type, ILog>();
        private static readonly object _lock = new object();

        static LogHelper()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetCallingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        private static ILog GetLogger(Type source)
        {
            lock (_lock)
            {
                if (_loggers.ContainsKey(source))
                {
                    return _loggers[source];
                }
                else
                {
                    ILog logger = LogManager.GetLogger(source);
                    _loggers.Add(source, logger);
                    return logger;
                }
            }
        }

        public static void Log(LoggingLevel loggingLevel, string message, Exception exception, object source)
        {
            ILog logger = GetLogger(source?.GetType());

            if (!IsLogEnable(logger, loggingLevel)) return;

            switch (loggingLevel)
            {
                case LoggingLevel.Debug:
                    logger.Debug(message, exception);
                    break;
                case LoggingLevel.Info:
                    logger.Info(message, exception);
                    break;
                case LoggingLevel.Warning:
                    logger.Warn(message, exception);
                    break;
                case LoggingLevel.Error:
                    logger.Error(message, exception);
                    break;
                case LoggingLevel.Fatal:
                    logger.Fatal(message, exception);
                    break;
            }

        }

        private static bool IsLogEnable(ILog logger, LoggingLevel loggingLevel)
        {
            switch (loggingLevel)
            {
                case LoggingLevel.Debug:
                    return logger.IsDebugEnabled;
                case LoggingLevel.Info:
                    return logger.IsInfoEnabled;
                case LoggingLevel.Warning:
                    return logger.IsWarnEnabled;
                case LoggingLevel.Error:
                    return logger.IsErrorEnabled;
                case LoggingLevel.Fatal:
                    return logger.IsFatalEnabled;
                default:
                    return false;
            }
        }

    }
}