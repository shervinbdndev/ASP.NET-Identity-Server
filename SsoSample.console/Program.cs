﻿using Newtonsoft.Json;
using SsoSample.MVC.Models;

namespace SsoSample.Console;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        
        client.BaseAddress = new Uri("https://localhost:7001");

        var stringResult = await client.GetStringAsync("/WeatherForecast");

        var result = JsonConvert.DeserializeObject<List<WeatherForecast>>(stringResult);

        foreach (var item in result!) {

            System.Console.WriteLine($"{item.Date}\t {item.Summery}\t {item.TemperatureC}\t {item.TemperatureF}");
            System.Console.WriteLine("".PadLeft(200, '-'));
        }

        System.Console.ReadLine();
    }
}