using Microsoft.Extensions.Options;

namespace Business.Entitites.Settings
{
    public class GlobalAppSettings
    {
        public AppSettings Settings { get; set; }
        public GlobalAppSettings(IOptions<AppSettings> settings) => Settings = settings.Value;
    }
}
