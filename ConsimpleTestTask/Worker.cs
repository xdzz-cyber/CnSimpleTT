using System.Text.Json;
using ConsimpleTestTask.Constants;
using ConsimpleTestTask.Models;

namespace ConsimpleTestTask;

public class Worker
{
    private static readonly HttpClient _httpClient = new();

    public static async Task<string> GetProductsAndCategoriesData(CancellationToken cancellationToken)
    {
        try
        {
            var httpResponseMessage = await _httpClient
                .GetAsync(ExternalResourcesPaths.ProductsNCategoriesPath, cancellationToken);

            if (!httpResponseMessage.IsSuccessStatusCode) return "Inner server error";

            var response = JsonSerializer
                .Deserialize<GeneralResponse>(await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken));
            
            return JsonSerializer.Serialize(response ?? throw new InvalidOperationException("Deserialization problem with general response while returning data of request"));
        }
        catch (Exception e)
        {
            // Serialization possible errors go here
            throw;
        }
    }
}