using FinanceAnalyser.Entities;

public interface IHuggingFaceCategoriser
{
    Task<string> CategoriseAsync(IEnumerable<Row> inputList);
}