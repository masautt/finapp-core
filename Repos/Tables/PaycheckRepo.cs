using Database;
using Microsoft.EntityFrameworkCore;
using Models.Tables;
using Repos.Interfaces;

namespace Repos.Tables;

public class PaycheckRepo(AppDbContext dbContext) : IPaycheckRepo
{

}
