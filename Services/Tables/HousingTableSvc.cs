using Models.Tables;
using Repos.Tables;
using Services.Tables.Interfaces;
using Services.Tables.Shared;

namespace Services.Tables;

public class HousingTableSvc(TableEntityRepo entityRepo) : EntityTableSvc<HousingTableDto>(entityRepo), IHousingTableSvc;