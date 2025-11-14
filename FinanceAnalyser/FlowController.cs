using FinanceAnalyser.Entities;
using FinanceAnalyser.Interfaces;

namespace FinanceAnalyser
{
    public class FlowController(ICsvReaderService _csvReader, IHuggingFaceCategoriser _categoriser) : IFlowController
    {
        public async Task StartFlowAsync()
        {
            Console.WriteLine("STARTING BANK STATEMENT ANALYSIS");

            var csv = _csvReader.ReadCsvFile("C:/Users/jyetr/Downloads/StatementCsv (1).csv");
            await _categoriser.CategoriseAsync(csv);

            Console.WriteLine("FINISHING BANK STATEMENT ANALYSIS");
        }
    }
}
