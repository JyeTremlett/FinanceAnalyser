using FinanceAnalyser.Interfaces;
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

            // Start app
            var host = builder.Build();
            var app = host.Services.GetRequiredService<FlowController>();
            app.StartFlow();
        }
    }
}
