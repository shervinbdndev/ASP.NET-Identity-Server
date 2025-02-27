using Newtonsoft.Json;
using SsoSample.MVC.Models;

namespace SsoSample.console;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        
        client.BaseAddress = new Uri("https://localhost:7001");

        var stringResult = await client.GetStringAsync("/WeatherForecast");

        var result = JsonConvert.DeserializeObject<List<WeatherForecast>>(stringResult);

        foreach (var item in result!) {

            Console.WriteLine($"{item.Date}\t {item.Summery}\t {item.TemperatureC}\t {item.TemperatureF}");
            Console.WriteLine("".PadLeft(200, '-'));
        }
        Console.ReadLine();
    }
}
