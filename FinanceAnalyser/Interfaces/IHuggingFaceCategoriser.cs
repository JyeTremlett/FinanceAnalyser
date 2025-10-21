public interface IHuggingFaceCategoriser
{
    Task<string> CategoriseAsync(string transaction);
}