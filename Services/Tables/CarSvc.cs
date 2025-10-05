using Models.Tables;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class CarSvc(EntityRepo entityRepo) : EntitySvc<CarDto>(entityRepo), ICarSvc;