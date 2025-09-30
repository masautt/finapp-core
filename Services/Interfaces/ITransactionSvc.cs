using Models;

namespace Services.Interfaces;

public interface ITransactionSvc
{
    Task<List<TransactionDto>> GetAllTransactionsAsync();
    Task<TransactionDto?> GetTransactionByIdAsync(string id);
    Task<List<TransactionDto>> GetTransactionsByDateRangeAsync(DateTime start, DateTime end);
    Task<List<TransactionDto>> GetTransactionsByAmountAsync(decimal? min, decimal? max);
    Task<List<TransactionDto>> GetTransactionsByCategoryAsync(string category);
    Task<List<TransactionDto>> GetTransactionsBySubCategoryAsync(string subCategory);
    Task<List<TransactionDto>> GetTransactionsByRecipientAsync(string recipient);
}