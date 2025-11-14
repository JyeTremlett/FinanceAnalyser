using FinanceAnalyser.Entities;

namespace FinanceAnalyser.Interfaces
{
    public interface ICsvReaderService
    {
        IEnumerable<Row> ReadCsvFile(string filePath);
    }
}
