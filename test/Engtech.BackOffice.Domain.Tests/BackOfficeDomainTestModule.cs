using Volo.Abp.Modularity;

namespace Engtech.BackOffice;

[DependsOn(
    typeof(BackOfficeDomainModule),
    typeof(BackOfficeTestBaseModule)
)]
public class BackOfficeDomainTestModule : AbpModule
{

}
