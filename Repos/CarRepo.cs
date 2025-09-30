using Database;
using Repos.Interfaces;

namespace Repos;

public class CarRepo(AppDbContext dbContext) : BaseRepo(dbContext), ICarRepo
{

}
