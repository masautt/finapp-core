using Models.Tables;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class HousingSvc(EntityRepo entityRepo) : EntitySvc<HousingDto>(entityRepo), IHousingSvc;