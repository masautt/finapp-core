using Database;
using Models.Transums;
using Repos.Transums.Shared;
using Services.Transums.Shared;

namespace Services.Transums;

public class TransumYrSvc(AppDbContext dbContext)
    : TransumCommonSvc<TransumYrDto, string>(new TransumCommonRepo<TransumYrDto, string>(dbContext, t => t.Year));