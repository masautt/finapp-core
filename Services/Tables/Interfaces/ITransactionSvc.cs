using Models.Tables;
using Services.Tables.Shared.Interfaces;

namespace Services.Tables.Interfaces;

public interface ITransactionSvc : IEntitySvc<TransactionDto>;