namespace Bai1.Configuration;

public class DatabaseSettings
{
    public string DefaultConnection { get; set; } = string.Empty;
}

public class AppConfig
{
    public DatabaseSettings ConnectionStrings { get; set; } = new();
}
