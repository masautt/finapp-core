using Models.Tables;
using Repos.Shared;
using Services.Interfaces;
using Services.Shared;

namespace Services.Tables;

public class TransactionSvc(EntityRepo entityRepo)
    : EntitySvc<TransactionDto>(entityRepo), ITransactionSvc;