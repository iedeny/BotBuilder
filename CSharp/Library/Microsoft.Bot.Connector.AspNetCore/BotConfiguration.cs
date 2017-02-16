using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Bot.Connector
{
    public class BotConfiguration : IBotConfiguration
    {        
        public string MicrosoftAppId
        {
            get
            {
                IConfigurationRoot configuration = BotServiceProvider.ServiceProvider.GetService(typeof(IConfigurationRoot)) as IConfigurationRoot;                
                return configuration?.GetSection(MicrosoftAppCredentials.MicrosoftAppIdKey)?.Value;
            }
        }

        public string MicrosoftAppPassword
        {
            get
            {
                IConfigurationRoot configuration = BotServiceProvider.ServiceProvider.GetService(typeof(IConfigurationRoot)) as IConfigurationRoot;
                return configuration?.GetSection(MicrosoftAppCredentials.MicrosoftAppPasswordKey)?.Value;
            }
        }
    }
}
