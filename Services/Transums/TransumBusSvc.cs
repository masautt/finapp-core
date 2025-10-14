using Database;
using Models.Transums;
using Repos.Transums.Shared;
using Services.Transums.Shared;

namespace Services.Transums;

public class TransumBusSvc(AppDbContext dbContext)
    : TransumCommonSvc<TransumBusDto, string>(new TransumCommonRepo<TransumBusDto, string>(dbContext, t => t.Business));