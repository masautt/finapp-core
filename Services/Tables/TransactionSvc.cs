using System.Linq.Expressions;
using Models.Tables;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class TransactionSvc(EntityRepo entityRepo)
    : EntitySvc<TransactionDto>(entityRepo), ITransactionSvc
{
    // Fetch all distinct subcategories, optionally filtered by a category
    public Task<List<string>> FetchSubcategories(string? category = null)
    {
        var filters = category != null
            ? new[] { (selector: (Expression<Func<TransactionDto, object>>)(t => t.Category), value: (object)category) }
            : Array.Empty<(Expression<Func<TransactionDto, object>>, object)>();

        return FetchDistinct(t => t.SubCategory, filters);
    }

    // Fetch all distinct businesses, optionally filtered by a category or subcategory
    public Task<List<string>> FetchBusinesses(string? category = null, string? subcategory = null)
    {
        var filterList = new List<(Expression<Func<TransactionDto, object>>, object)>();
        if (category != null) filterList.Add((t => t.Category, category));
        if (subcategory != null) filterList.Add((t => t.SubCategory, subcategory));

        return FetchDistinct(t => t.Business, filterList.ToArray());
    }
}