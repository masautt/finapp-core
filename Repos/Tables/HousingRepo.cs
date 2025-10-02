using Database;
using Repos.Interfaces;

namespace Repos.Tables;

public class HousingRepo(AppDbContext dbContext) : IHousingRepo
{
}
