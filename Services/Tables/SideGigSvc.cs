using Models.Tables;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class SideGigSvc(EntityRepo entityRepo)
    : EntitySvc<SideGigDto>(entityRepo), ISideGigSvc;