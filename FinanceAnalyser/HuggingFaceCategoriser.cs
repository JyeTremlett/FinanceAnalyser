using HuggingFace;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class HuggingFaceCategoriser(IConfiguration _config) : IHuggingFaceCategoriser
{
    private readonly HttpClient _http = new();
    private readonly string _apiKey = _config.GetValue<string>("HuggingFaceToken")
        ?? throw new InvalidOperationException("Could not get user secrets");

    public async Task<string> CategoriseAsync()
    {
        string result = string.Empty;

        try
        {
            var body = new { inputs = "I love my new budgeting app!" };
            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            Console.WriteLine("Starting Request");

            var resp = await _http.PostAsync(
                "https://router.huggingface.co/v1/moonshotai/Kimi-K2-Instruct-0905",
                content
            );
            Console.WriteLine("Finishing request");

            resp.EnsureSuccessStatusCode();
            result = await resp.Content.ReadAsStringAsync();

            Console.WriteLine("Result was: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during categorisation: " + ex.Message);
            throw;
        }

        return result;







    }

    public async Task AltCategoriseAsync()
    {
        //var client = new HttpClient();
        //client.DefaultRequestHeaders.Authorization =
        //new AuthenticationHeaderValue("Bearer", _apiKey);

        //var body = new 
        //{ 
        //    //inputs = "I love my new budgeting app!"
        //    role = "user",
        //    content = "Explain the theory of relativity in simple terms."
        //};
        //var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

        //var response = await client.PostAsync(
        //    "https://router.huggingface.co/v1/moonshotai/Kimi-K2-Instruct-0905",
        //    content
        //);

        //response.EnsureSuccessStatusCode();

        //var result = await response.Content.ReadAsStringAsync();
        //Console.WriteLine(result);

    }

}
