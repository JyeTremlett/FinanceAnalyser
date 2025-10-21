using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class HuggingFaceCategoriser : IHuggingFaceCategoriser
{
    private readonly HttpClient _http = new();
    private readonly string _apiKey;

    public HuggingFaceCategoriser(string apiKey)
    {
        _apiKey = apiKey;
        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _apiKey);
    }

    public async Task<string> CategoriseAsync(string transaction)
    {
        var body = new { inputs = transaction };
        var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");
        var resp = await _http.PostAsync(
            "https://api-inference.huggingface.co/models/finetuned-distilbert", // Replace with model ID
            content
        );
        resp.EnsureSuccessStatusCode();
        var result = await resp.Content.ReadAsStringAsync();
        return result;
    }
}
