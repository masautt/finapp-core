using Models.Tables;
using Repos.Tables;
using Services.Tables.Interfaces;
using Services.Tables.Shared;

namespace Services.Tables;

public class TransactionSvc(EntityRepo entityRepo)
    : EntitySvc<TransactionDto>(entityRepo), ITransactionSvc;