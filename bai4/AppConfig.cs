using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using bai4.Models;

namespace bai4;

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

    public static PaymentConfig Payment
    {
        get
        {
            var config = Configuration.GetSection("Payment").Get<PaymentConfig>();
            return config ?? new PaymentConfig();
        }
    }

    public static string ConnectionString
    {
        get
        {
            return Configuration.GetConnectionString("QL_TraSuaConnection")
                ?? "Server=.\\SQLEXPRESS;Database=QL_TraSua;Integrated Security=True;TrustServerCertificate=True;";
        }
    }
}
