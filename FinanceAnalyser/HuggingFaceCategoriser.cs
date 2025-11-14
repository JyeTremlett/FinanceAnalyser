using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;

public class HuggingFaceCategoriser(IConfiguration _config) : IHuggingFaceCategoriser
{
    private readonly string _apiKey = _config.GetValue<string>("HuggingFaceToken")
        ?? throw new InvalidOperationException("Could not get user secrets");

    public async Task<string> CategoriseAsync()
    {
        string model = "deepset/roberta-base-squad2";
        using var http = new HttpClient();
        string url = $"https://router.huggingface.co/hf-inference/models/{model}";

        http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _apiKey);

        string json = """
        {
          "inputs": {
            "question": "What is my name?",
            "context": "My name is Clara and I live in Berkeley."
          }
        }
        """;

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await http.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);

        return "";
    }
}
