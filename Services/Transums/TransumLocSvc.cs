using Database;
using Models.Transums;
using Repos.Transums.Shared;
using Services.Transums.Shared;

namespace Services.Transums;

public class TransumLocSvc(AppDbContext dbContext)
    : TransumCommonSvc<TransumLocDto, object>(
        new TransumCommonRepo<TransumLocDto, object>(
            dbContext,
            t => new { t.City, t.State }
        )
    );