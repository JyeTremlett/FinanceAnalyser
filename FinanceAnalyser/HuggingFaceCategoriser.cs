using FinanceAnalyser.Entities;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class HuggingFaceCategoriser(IConfiguration _config) : IHuggingFaceCategoriser
{
    private readonly string _apiKey = _config.GetValue<string>("HuggingFaceToken")
        ?? throw new InvalidOperationException("Error retrieving HuggingFaceToken");

    public async Task<string> CategoriseAsync(IEnumerable<Row> inputList)
    {
        Console.WriteLine("Starting classification");
        using var http = new HttpClient();
        string url = $"https://router.huggingface.co/hf-inference/models/facebook/bart-large-mnli";
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        string[] transactions = inputList.Select(x => x.Description).ToArray();
        string[] labels = { "Groceries", "Fuel", "Rent", "Eating Out", "Bills", "Entertainment", "Drinks at the bar", "Public Transport", "Unkown" };

        var input = new
        {
            inputs = transactions,
            parameters = new
            {
                candidate_labels = labels
            }
        };

        string jsonInput = JsonSerializer.Serialize(input);
        var content = new StringContent(jsonInput, Encoding.UTF8, "application/json");

        var response = await http.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);

        Console.WriteLine("Finishing classification");
        return "";
    }
}
