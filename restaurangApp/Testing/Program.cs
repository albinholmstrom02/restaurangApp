using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var httpClient = new HttpClient();

        httpClient.BaseAddress = new Uri("https://localhost:7114/");

        try
        {
            HttpResponseMessage responseDishes = await httpClient.GetAsync("api/dishes/get");
            HttpResponseMessage responseOrders = await httpClient.GetAsync("api/orders/get");

            responseDishes.EnsureSuccessStatusCode();
            responseOrders.EnsureSuccessStatusCode();

            Console.WriteLine("API-response: Communication with API working as expected!");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.ReadLine();
    }
}
