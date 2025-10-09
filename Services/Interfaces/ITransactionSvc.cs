using Models.Tables;

namespace Services.Interfaces;

public interface ITransactionSvc : IEntitySvc<TransactionDto>
{
    // Fetch distinct subcategories, optionally filtered by category
    Task<List<string>> FetchSubcategories(string? category = null);

    // Fetch distinct businesses, optionally filtered by category and subcategory
    Task<List<string>> FetchBusinesses(string? category = null, string? subcategory = null);
}