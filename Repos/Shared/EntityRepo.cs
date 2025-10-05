namespace Repos.Shared;

public class EntityRepo(CommonRepo commonRepo, DateRepo dateRepo)
{
    public CommonRepo CommonRepo { get; } = commonRepo ?? throw new ArgumentNullException(nameof(commonRepo));
    public DateRepo DateRepo { get; } = dateRepo ?? throw new ArgumentNullException(nameof(dateRepo));
}