using FinanceAnalyser.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinanceAnalyser
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            // Add config and app secrets
            builder.Configuration.AddUserSecrets<Program>();

            // Register services
            builder.Services.AddSingleton<FlowController>();
            builder.Services.AddSingleton(builder.Configuration);

            builder.Services.AddScoped<ICsvReaderService, CsvReaderService>();
            builder.Services.AddScoped<IHuggingFaceCategoriser, HuggingFaceCategoriser>();

            var host = builder.Build();

            // Retrieve App Secrets
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            // Start app
            var app = host.Services.GetRequiredService<FlowController>();
            await app.StartFlowAsync();
        }
    }
}
