using Database;
using Models.Transums;
using Repos.Transums.Shared;
using Services.Transums.Shared;

namespace Services.Transums;

public class TransumCatSvc(AppDbContext dbContext)
    : TransumCommonSvc<TransumCatDto, string>(new TransumCommonRepo<TransumCatDto, string>(dbContext, t => t.Category));