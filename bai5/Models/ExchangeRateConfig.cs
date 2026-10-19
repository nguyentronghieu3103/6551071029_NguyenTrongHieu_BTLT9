namespace bai5.Models;

public class ExchangeRateConfig
{
    public string PrimaryUrl { get; set; } = "https://cdn.jsdelivr.net/npm/@fawazahmed0/currencyapi@latest/v1/currencies/{code}.json";
    public string BackupUrl { get; set; } = "https://latest.currency-api.pages.dev/v1/currencies/{code}.json";
    public int TimeoutSeconds { get; set; } = 10;
    public int CacheDurationMinutes { get; set; } = 10;
}
