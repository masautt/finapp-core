using Models;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services;

public class TransactionSvc(ITransactionRepo transactionRepo) : ITransactionSvc
{
    private readonly ITransactionRepo _transactionRepo = transactionRepo;

    public async Task<List<TransactionDto>> GetAllTransactionsAsync()
    {
        return await _transactionRepo.FetchAllAsync();
    }

    public async Task<TransactionDto?> GetTransactionByIdAsync(string id)
    {
        return await _transactionRepo.FetchByIdAsync(id);
    }

    public async Task<List<TransactionDto>> GetTransactionsByDateRangeAsync(DateTime start, DateTime end)
    {
        return await _transactionRepo.FetchByDateRangeAsync(start, end);
    }

    public async Task<List<TransactionDto>> GetTransactionsByAmountAsync(decimal? min, decimal? max)
    {
        return await _transactionRepo.FetchByAmountAsync(min, max);
    }

    public async Task<List<TransactionDto>> GetTransactionsByCategoryAsync(string category)
    {
        return await _transactionRepo.FetchByCategoryAsync(category);
    }

    public async Task<List<TransactionDto>> GetTransactionsBySubCategoryAsync(string subCategory)
    {
        return await _transactionRepo.FetchBySubCategoryAsync(subCategory);
    }

    public async Task<List<TransactionDto>> GetTransactionsByRecipientAsync(string recipient)
    {
        return await _transactionRepo.FetchByRecipientAsync(recipient);
    }
}