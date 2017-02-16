using System.Configuration;

namespace Microsoft.Bot.Connector
{
    public class BotConfiguration : IBotConfiguration
    {
        public string MicrosoftAppId
        {
            get
            {
                return ConfigurationManager.AppSettings[MicrosoftAppCredentials.MicrosoftAppIdKey];
            }
        }

        public string MicrosoftAppPassword
        {
            get
            {
                return ConfigurationManager.AppSettings[MicrosoftAppCredentials.MicrosoftAppPasswordKey];
            }
        }
    }
}
