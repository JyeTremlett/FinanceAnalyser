using FinanceAnalyser.Entities;
using FinanceAnalyser.Interfaces;

namespace FinanceAnalyser
{
    public class CsvReaderService : ICsvReaderService
    {
        public IEnumerable<Row> ReadCsvFile(string filePath)
        {
            Console.WriteLine("Starting CSV file reading");
            var processedRecords = new List<Row>();

            var lines = File.ReadAllLines(filePath);

            var headers = lines[0].Split(',');
            var line = "";
            var values = new string[lines[0].Length];

            for (int i = 0; i < lines.Length-1; i++)
            {
                line = lines[i + 1];
                values = line.Split(',');

                processedRecords.Add(new Row { Date = values[1], Description = values[2], Amount = values[3], Balance = values[4] });
            }

            Console.WriteLine("Finishing CSV file reading");
            return processedRecords;
        }
    }
}
