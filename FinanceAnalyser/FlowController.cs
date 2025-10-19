using FinanceAnalyser.Interfaces;

namespace FinanceAnalyser
{
    public class FlowController(ICsvReaderService _csvReader) : IFlowController
    {
        public void StartFlow()
        {
            Console.WriteLine("STARTING BANK STATEMENT ANALYSIS");

            ReadCsvFile();

            Console.WriteLine("FINISHING BANK STATEMENT ANALYSIS");
        }

        public void ReadCsvFile()
        {
            _csvReader.ReadCsvFile("C:/Users/jyetr/Downloads/StatementCsv.csv");
        }
    }
}
