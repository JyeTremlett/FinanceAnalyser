using FinanceAnalyser.Interfaces;

namespace FinanceAnalyser
{
    public class CsvReaderService : ICsvReaderService
    {
        public void ReadCsvFile(string filePath)
        {
            // Get lines from CSV file
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            // Assume first line is headers
            var headers = lines[0].Split(',');
            var records = new List<Dictionary<string, string>>();

            // Process lines

        }
    }
}
