using FinanceAnalyser.Interfaces;

namespace FinanceAnalyser
{
    public class FlowController(ICsvReaderService _csvReader, IHuggingFaceCategoriser _categoriser) : IFlowController
    {
        public async Task StartFlowAsync()
        {
            Console.WriteLine("STARTING BANK STATEMENT ANALYSIS");

            //ReadCsvFile();
            //await _categoriser.CategoriseAsync("Test transaction for categorisation");
            await _categoriser.CategoriseAsync();

            Console.WriteLine("FINISHING BANK STATEMENT ANALYSIS");
        }

        public void ReadCsvFile()
        {
            _csvReader.ReadCsvFile("C:/Users/jyetr/Downloads/StatementCsv.csv");
        }
    }
}
