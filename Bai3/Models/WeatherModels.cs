using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bai3.Models;

public class GeocodingResponse
{
    [JsonPropertyName("results")]
    public List<GeocodingResult>? Results { get; set; }
}

public class GeocodingResult
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("admin1")]
    public string? Admin1 { get; set; }
}

public class ForecastResponse
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("daily")]
    public DailyForecastData? Daily { get; set; }
}

public class DailyForecastData
{
    [JsonPropertyName("time")]
    public List<string> Time { get; set; } = new();

    [JsonPropertyName("weather_code")]
    public List<int> WeatherCode { get; set; } = new();

    [JsonPropertyName("temperature_2m_max")]
    public List<double> Temperature2mMax { get; set; } = new();

    [JsonPropertyName("temperature_2m_min")]
    public List<double> Temperature2mMin { get; set; } = new();

    [JsonPropertyName("precipitation_probability_max")]
    public List<int?> PrecipitationProbabilityMax { get; set; } = new();
}

public enum WeatherCategory
{
    Clear,          // 0
    Cloudy,         // 1, 2, 3
    Fog,            // 45, 48
    Rain,           // 51-67, 80-82
    Thunderstorm    // 95-99
}

public class WeatherForecastResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsBeyondForecastRange { get; set; }
    public bool LocationNotFound { get; set; }
    public string? LocationSuggestedName { get; set; }

    public string DestinationName { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public int WeatherCode { get; set; }
    public string WeatherDescriptionVi { get; set; } = string.Empty;
    public string WeatherDescriptionEn { get; set; } = string.Empty;
    public double MinTemperature { get; set; }
    public double MaxTemperature { get; set; }
    public int PrecipitationProbability { get; set; }
    public WeatherCategory Category { get; set; }

    public string GetDescription(bool isVietnamese) =>
        isVietnamese ? WeatherDescriptionVi : WeatherDescriptionEn;
}
