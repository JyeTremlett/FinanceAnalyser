using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

public class HuggingFaceCategoriser(IConfiguration _config) : IHuggingFaceCategoriser
{
    private readonly string _apiKey = _config.GetValue<string>("HuggingFaceToken")
        ?? throw new InvalidOperationException("Error retrieving HuggingFaceToken");

    public async Task<string> CategoriseAsync()
    {
        using var http = new HttpClient();
        string url = $"https://router.huggingface.co/hf-inference/models/facebook/bart-large-mnli";

        http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _apiKey);


        string transaction = "WOOLWORTHS 4567 SUBIACO WA";
        string[] labels = { "Groceries", "Fuel", "Rent", "Eating Out", "Bills", "Entertainment", "Transfer" };

        string jsonPayload = """
        {
            "inputs": "Hi, I recently bought a device from your company but it is not working as advertised and I would like to get reimbursed!",
            "parameters": {"candidate_labels": ["refund", "legal", "faq"]}
        }
        """;

        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        var response = await http.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);

        return "";
    }
}
