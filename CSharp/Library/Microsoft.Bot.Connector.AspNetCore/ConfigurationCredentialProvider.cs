using Microsoft.Extensions.Configuration;

namespace Microsoft.Bot.Connector
{
    /// <summary>
    /// Credential provider which uses <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> to lookup appId and password
    /// </summary>
    public sealed class ConfigurationCredentialProvider : SimpleCredentialProvider
    {
        public ConfigurationCredentialProvider(IConfiguration configuration,
            string appIdSettingName = null,
            string appPasswordSettingName = null)
        {
            var appIdKey = appIdSettingName ?? MicrosoftAppCredentials.MicrosoftAppIdKey;
            var passwordKey = appPasswordSettingName ?? MicrosoftAppCredentials.MicrosoftAppPasswordKey;
            this.AppId = configuration.GetSection(appIdKey)?.Value;
            this.Password = configuration.GetSection(passwordKey)?.Value;
        }
    }
}
