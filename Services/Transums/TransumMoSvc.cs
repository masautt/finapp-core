using Database;
using Models.Transums;
using Repos.Transums.Shared;
using Services.Transums.Shared;

namespace Services.Transums;

public class TransumMoSvc(AppDbContext dbContext)
    : TransumCommonSvc<TransumMoDto, string>(new TransumCommonRepo<TransumMoDto, string>(dbContext, t => t.Month));