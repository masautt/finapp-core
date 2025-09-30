using Models;
using Repos;
using Repos.Interfaces;
using Services.Interfaces;

namespace Services;

public class CarSvc(ICarRepo carRepo) : BaseSvc<CarDto, CarRepo>((CarRepo)carRepo), ICarSvc
{
}