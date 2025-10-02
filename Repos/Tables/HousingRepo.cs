using Database;
using Microsoft.EntityFrameworkCore;
using Models.Tables;
using Repos.Interfaces;

namespace Repos;

public class HousingRepo(AppDbContext dbContext) : IHousingRepo
{
}
