using Volo.Abp.Modularity;

namespace Engtech.BackOffice;

public abstract class BackOfficeApplicationTestBase<TStartupModule> : BackOfficeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
