using Database;
using Models.Transums;
using Repos.Transums.Shared;
using Services.Transums.Shared;

namespace Services.Transums;

public class TransumSubSvc(AppDbContext dbContext)
    : TransumCommonSvc<TransumSubDto, string>(new TransumCommonRepo<TransumSubDto, string>(dbContext, t => t.SubCategory));