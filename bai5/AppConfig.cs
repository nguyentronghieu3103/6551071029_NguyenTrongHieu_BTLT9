using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using bai5.Models;

namespace bai5;

public static class AppConfig
{
    private static IConfigurationRoot? _configuration;

    public static IConfigurationRoot Configuration
    {
        get
        {
            if (_configuration == null)
            {
                Initialize();
            }
            return _configuration!;
        }
    }

    public static void Initialize()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        _configuration = builder.Build();
    }

    public static ExchangeRateConfig ExchangeRate
    {
        get
        {
            var config = Configuration.GetSection("ExchangeRate").Get<ExchangeRateConfig>();
            return config ?? new ExchangeRateConfig();
        }
    }

    public static string ConnectionString
    {
        get
        {
            return Configuration.GetConnectionString("QL_DatTourConnection")
                ?? "Server=.\\SQLEXPRESS;Database=QL_DatTour;Integrated Security=True;TrustServerCertificate=True;";
        }
    }

    public static string StoreName
    {
        get
        {
            return Configuration["App:StoreName"] ?? "Binh An";
        }
    }

    public static string Version
    {
        get
        {
            return Configuration["App:Version"] ?? "1.0.0";
        }
    }
}
