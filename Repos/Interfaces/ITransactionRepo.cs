using Models;

namespace Repos.Interfaces;

public interface ITransactionRepo
{
    Task<List<TransactionDto>> FetchAllAsync();
    Task<TransactionDto?> FetchByIdAsync(string id);
    Task<List<TransactionDto>> FetchByDateRangeAsync(DateTime start, DateTime end);
    Task<List<TransactionDto>> FetchByAmountAsync(decimal? min, decimal? max);
    Task<List<TransactionDto>> FetchByCategoryAsync(string category);
    Task<List<TransactionDto>> FetchBySubCategoryAsync(string subCategory);
    Task<List<TransactionDto>> FetchByRecipientAsync(string recipient);
}