using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Bot.Connector.AspNetCore
{
    public class Logger : ILogger
    {
        private ILogger logger;

        public Logger()
        {
            ILoggerFactory factory = BotServiceProvider.ServiceProvider.GetService(typeof(ILoggerFactory)) as ILoggerFactory;
            this.logger = factory.CreateLogger("Microsoft.Bot.Connector");
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this.logger.BeginScope(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return this.logger.IsEnabled(logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            this.logger.Log(logLevel, eventId, state, exception, formatter);
        }
    }
}
