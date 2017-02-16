using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Bot.Connector
{
    public static class BotServiceProvider
    {
        private static IServiceCollection serviceCollection;

        internal static IServiceProvider ServiceProvider
        {
            get
            {
                if (serviceCollection == null)
                {
                    throw new InvalidOperationException($"{nameof(serviceCollection)} is not defined. Please call services.UseBotConnector() in your ASP.NET Core Startup Configure method.");
                }

                return serviceCollection.BuildServiceProvider();
            }
        }

        public static void UseBotConnector(this IServiceCollection serviceCollection)
        {
            BotServiceProvider.serviceCollection = serviceCollection;
        }
    }
}
