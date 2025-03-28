﻿using System.Text.Json;
using System.Text.Json.Serialization;

const string KEY = "3fe3618da3f5d90fb993d05aa32c0afc";

string city = Console.ReadLine();

using (HttpClient client = new())
try
{
    string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={KEY}";
    HttpResponseMessage responce = await client.GetAsync(url);

    if(responce.IsSuccessStatusCode)
    {
        string result = await responce.Content.ReadAsStringAsync();
        WeatherData weatherInfo = JsonSerializer.Deserialize<WeatherData>(result);
        Console.WriteLine($"Shahar nomi: {weatherInfo.name}\nTemperature: {weatherInfo.main.Temp - 273.15f:F0}\nMa'lumot: {weatherInfo.weather[0].Description}");

    }
    else
    {
        Console.WriteLine($"Error: {responce.StatusCode}");
    }
}
catch(Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
}