using FinanceAnalyser.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinanceAnalyser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddSingleton<FlowController>();
            builder.Services.AddScoped<ICsvReaderService, CsvReaderService>();

            var host = builder.Build();

            // Retrieve App Secrets
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            string fakeTestToken = config.GetValue<string>("fakeTestToken") ?? throw new InvalidOperationException("Could not get user secrets");

            // Start app
            var app = host.Services.GetRequiredService<FlowController>();
            app.StartFlow();
        }
    }
}
