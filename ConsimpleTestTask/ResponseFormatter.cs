using System.Text.Json;
using ConsimpleTestTask.Models;
using ConsoleTables;

namespace ConsimpleTestTask;

public static class ResponseFormatter
{
    public static void ShowBuiltResponseTable(string generalResponse)
    {
        try
        {
            Console.WriteLine(BuildTable(JsonSerializer.Deserialize<GeneralResponse>(generalResponse)
                                         ?? throw new InvalidOperationException("Deserialization problem with general response while formatting")).ToString());
        }
        catch (Exception e)
        {
            // Serialization possible errors go here
            throw;
        }
    }

    private static ConsoleTable BuildTable(GeneralResponse generalResponse)
    {
        var table = new ConsoleTable("Product name", "Category name");

        foreach (var product in generalResponse.Products)
            table.AddRow(product.Name,
                generalResponse.Categories.First(category => category.Id == product.CategoryId).Name);

        return table;
    }
}