namespace OrderShopApi.Services;

/// <summary>
/// Serwis odczytu ustawień z settings.json
/// </summary>
public class SettingsService
{
    readonly JsonSerializerOptionsService jsonSerializerOptionsService;

    public Settings SettingsFetched { get; set; }

    public SettingsService(JsonSerializerOptionsService _jsonSerializerOptionsService)
    {
        jsonSerializerOptionsService = _jsonSerializerOptionsService;
        readJson();
    }

    private async void readJson()
    {
        try
        {
            SettingsFetched = await JsonSerializer.DeserializeAsync<Settings>(new FileStream("settings.json", FileMode.Open), jsonSerializerOptionsService.Options);
            if (SettingsFetched == null)
            {
                throw new Exception("Błąd odczytania ustawień");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public class Settings
    {
        public string Mail { get; set; } = string.Empty;
        public string Sender { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 0;
        public string TargetMail { get; set; } = string.Empty;

    }
}
