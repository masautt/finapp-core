using Database;
using Microsoft.EntityFrameworkCore;
using Models.Tables;
using Repos.Interfaces;

namespace Repos.Tables;

public class TransactionRepo(AppDbContext dbContext) : ITransactionRepo
{
  
}