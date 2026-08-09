using Volo.Abp.Modularity;

namespace Engtech.BackOffice;

/* Inherit from this class for your domain layer tests. */
public abstract class BackOfficeDomainTestBase<TStartupModule> : BackOfficeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
