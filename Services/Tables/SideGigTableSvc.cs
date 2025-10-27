using Models.Tables;
using Repos.Tables;
using Services.Tables.Interfaces;
using Services.Tables.Shared;

namespace Services.Tables;

public class SideGigTableSvc(TableEntityRepo entityRepo)
    : EntityTableSvc<SideGigTableDto>(entityRepo), ISideGigTableSvc;