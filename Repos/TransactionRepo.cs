using Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Repos.Interfaces;

namespace Repos;

public class TransactionRepo(AppDbContext dbContext) : ITransactionRepo
{
    public async Task<List<TransactionDto>> FetchAllAsync()
    {
        return await dbContext.Transactions.ToListAsync();
    }

    public async Task<TransactionDto?> FetchByIdAsync(string id)
    {
        return await dbContext.Transactions
            .FirstOrDefaultAsync(t => t.Common.Id == id);
    }

    public async Task<List<TransactionDto>> FetchByDateRangeAsync(DateTime start, DateTime end)
    {
        return await dbContext.Transactions
            .Where(t => t.Date.Date >= start && t.Date.Date <= end)
            .ToListAsync();
    }

    public async Task<List<TransactionDto>> FetchByAmountAsync(decimal? min, decimal? max)
    {
        var query = dbContext.Transactions.AsQueryable();
        if (min.HasValue) query = query.Where(t => t.Amount >= min.Value);
        if (max.HasValue) query = query.Where(t => t.Amount <= max.Value);
        return await query.ToListAsync();
    }

    public async Task<List<TransactionDto>> FetchByCategoryAsync(string category)
    {
        return await dbContext.Transactions
            .Where(t => t.Category == category)
            .ToListAsync();
    }

    public async Task<List<TransactionDto>> FetchBySubCategoryAsync(string subCategory)
    {
        return await dbContext.Transactions
            .Where(t => t.SubCategory == subCategory)
            .ToListAsync();
    }

    public async Task<List<TransactionDto>> FetchByRecipientAsync(string recipient)
    {
        return await dbContext.Transactions
            .Where(t => t.Recipient == recipient)
            .ToListAsync();
    }
}