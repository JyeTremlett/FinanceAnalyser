public interface IHuggingFaceCategoriser
{
    Task<string> CategoriseAsync();
    Task AltCategoriseAsync();
}