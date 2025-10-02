using Repos.Shared;
using Services.Shared;

public class CommonSvcWrapper : CommonSvc
{
    public CommonSvcWrapper(CommonRepo commonRepo)
        : base(commonRepo) // only one argument now
    {
    }
}