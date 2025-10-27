namespace Repos.Tables;

public class TableEntityRepo(TableCommonRepo commonRepo, TableDateRepo dateRepo)
{
    public TableCommonRepo CommonRepo { get; } = commonRepo ?? throw new ArgumentNullException(nameof(commonRepo));
    public TableDateRepo DateRepo { get; } = dateRepo ?? throw new ArgumentNullException(nameof(dateRepo));
}